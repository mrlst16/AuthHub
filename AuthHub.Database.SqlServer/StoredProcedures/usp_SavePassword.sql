CREATE PROCEDURE [dbo].[usp_SavePassword]
	@request udt_Password readonly,
	@claims udt_Claim readonly
AS
Begin Transaction
Begin Try
	
	if (select count(*) from @request) > 1
	Begin
		;throw 50001 , 'Cannot merge more than 1 password at a time', 1
	End

	declare @passwordIds table(
		value uniqueidentifier
	);

	merge Password as Target
	using @request as Source
	on (
		Target.FK_User = Source.FK_User
			and Target.DeletedUTC is null
	)
	when matched
	then update set
		Target.Username = Source.Username,
		Target.PasswordHash = Source.PasswordHash,
		Target.Salt = Source.Salt,
		Target.HashLength = Source.HashLength,
		Target.ModifiedUTC = getutcdate()
	when not matched
	then insert
	(Id, FK_User, UserName, PasswordHash, Salt, HashLength)
	values
	(newid(), Source.FK_User, Source.Username, Source.PasswordHash,Source.Salt, Source.HashLength)
	Output inserted.Id
	into @passwordIds;

	declare @passwordId uniqueidentifier = (select top 1 value from @passwordIds)

	select @passwordId as Id;

	merge Claim as Target
	using @claims as Source
	on (
		Target.FK_Password = Source.FK_Password
			and Target.FK_ClaimsKey = Target.FK_ClaimsKey
	)
	when matched
	then update set
		Target.Value = Source.Value
	when not matched
	then insert 
	(Id, FK_Password, FK_ClaimsKey, Name, Value)
	values
	(newid(), @passwordId, Source.FK_ClaimsKey, Source.Name, Source.Value);

Commit Transaction
End Try
Begin Catch
	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
	Rollback Transaction
End Catch
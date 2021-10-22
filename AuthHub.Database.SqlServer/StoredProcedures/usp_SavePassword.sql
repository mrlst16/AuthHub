CREATE PROCEDURE [dbo].[usp_SavePassword]
	@request udt_Password readonly
AS
Begin Transaction
Begin Try
	merge Password as Target
	using @request as Source
	on (Target.FK_User = Source.FK_User
			and Target.DeletedUTC is not null
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
	Output inserted.Id;
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


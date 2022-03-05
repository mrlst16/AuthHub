CREATE PROCEDURE [dbo].[usp_SaveUser]
	@request udt_User readonly
AS
Begin Transaction
Begin Try
	merge [User] as Target
	using @request as Source
	on (
		Target.FK_AuthSettings = Source.FK_AuthSettings
		and Target.Email = Source.Email
		and Target.DeletedUTC is null
		)
	when matched
	then update set
		Target.Username = Source.Username,
		Target.FK_AuthSettings = Source.FK_AuthSettings,
		Target.Email = Source.Email,
		Target.ModifiedUTC = getutcdate()
	when not matched
	then insert
	(Id, FK_AuthSettings, Username, Email, FirstName, LastName)
	values
	(newid(), Source.FK_AuthSettings, Source.Username, Source.Email, Source.FirstName, Source.LastName)
	output inserted.Id;
Commit Transaction
End Try
Begin Catch
	if @@TRANCOUNT > 0
	Begin
		Rollback Transaction
	End
	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
	Rollback Transaction
End Catch
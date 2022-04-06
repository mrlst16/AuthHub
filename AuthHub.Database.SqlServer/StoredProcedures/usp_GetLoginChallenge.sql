CREATE PROCEDURE [dbo].[usp_GetLoginChallenge]
	@authSettingsId uniqueidentifier,
	@userName nvarchar(200)
AS
Begin Transaction
Begin Try
	
	select top 1 u.*
	from [User](nolock) u
	join Password(nolock) p on p.FK_User = u.Id
	where u.FK_AuthSettings = @authSettingsId
	and u.Username = @userName
	and u.DeletedUTC is null

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
End Catch
Commit Transaction
CREATE PROCEDURE [dbo].[usp_GetClaimsKeys]
	@authSettingsId uniqueidentifier = null
AS
Begin Transaction
Begin Try

	select *
	from ClaimsKey(nolock)
	where FK_AuthSettings = @authSettingsId
	and DeletedUTC is null

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
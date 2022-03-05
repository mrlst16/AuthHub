CREATE PROCEDURE [dbo].[usp_GetLoginChallengeModel]
	@authSettingsId uniqueidentifier,
	@username nvarchar(200)
AS
Begin Try


	if @authSettingsId is null or @authSettingsId = cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier)
	Begin
		return
	End
	
	select *
	from AuthSettings(nolock)
	where Id = @authSettingsId

	select *
	from [User](nolock) u
	where u.FK_AuthSettings = @authSettingsId
	and u.Username = @username
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
RETURN 0
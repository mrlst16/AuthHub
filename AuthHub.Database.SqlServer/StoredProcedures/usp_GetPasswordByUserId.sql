CREATE PROCEDURE [dbo].[usp_GetPasswordByUserId]
	@userId uniqueidentifier 
AS
Begin Transaction Body
Begin Try

	select top 1 *
	from Password(nolock)
	where FK_User = @userId
	and DeletedUTC is null

Commit Transaction Body
	End Try
	Begin Catch
	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;

	if @@trancount > 0
	Begin
		Rollback Transaction Body
	End
End Catch
CREATE PROCEDURE [dbo].[usp_GetPasswordResetToken]
	@userId uniqueidentifier
AS
Begin Transaction
Begin Try

select top 1 *
from PasswordResetToken(nolock)
where FK_User = @userId
and ExpirationDate > getutcdate()
order by ExpirationDate desc

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
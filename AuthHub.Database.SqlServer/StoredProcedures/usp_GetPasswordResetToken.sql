CREATE PROCEDURE [dbo].[usp_GetPasswordResetToken]
	@email nvarchar(200),
	@organizationId uniqueidentifier,
	@authSettingsName nvarchar(200)
AS
Begin Transaction
Begin Try

select * from 
(select top 1 *
from PasswordResetToken(nolock)
where Email = @email
and OrganizationID = @organizationId
and AuthSettingsName = @authSettingsName
) query
order by Count

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
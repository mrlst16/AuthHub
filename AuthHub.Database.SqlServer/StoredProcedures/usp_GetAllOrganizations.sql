CREATE PROCEDURE [dbo].[usp_GetAllOrganizations]
AS
Begin Transaction
Begin Try
	select *
	from Organization(nolock)
	where DeletedUTC is null
End Try
Begin Catch
	Rollback Transaction
	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
End Catch
Commit Transaction

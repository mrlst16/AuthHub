CREATE PROCEDURE [dbo].[usp_GetOrganization]
	@id uniqueidentifier
AS

Begin Try
	select *
	from Organization(nolock)
	where Id = @id
	and DeletedUTC is null
End Try
Begin Catch
	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
End Catch
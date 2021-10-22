CREATE PROCEDURE [dbo].[usp_GetAuthSettings]
	@Id uniqueidentifier = null,
	@OrganizationId uniqueidentifier,
	@Name nvarchar(200)
AS
Begin Try

	select top 1 *
	from AuthSettings(nolock)
	where Id = @id
	or (FK_Organization = @OrganizationId
		and [Name] = @Name)
		and DeletedUTC is null
	order by CreatedUTC
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
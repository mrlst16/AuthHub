CREATE PROCEDURE [dbo].[usp_GetAuthSettings]
	@Id uniqueidentifier = null,
	@OrganizationId uniqueidentifier,
	@Name nvarchar(200)
AS
Begin Transaction
Begin Try

	select top 1 a.*, s.Value as AuthScheme
	from AuthSettings(nolock) a
	join AuthScheme s on s.Id = a.FK_AuthScheme
	where a.Id = @id
	or (
		a.FK_Organization = @OrganizationId
		and a.[Name] = @Name
		)
		and a.DeletedUTC is null
	order by a.CreatedUTC

	select *
	from [User](nolock)
	where FK_AuthSettings = @Id
	and DeletedUTC is null

commit transaction
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
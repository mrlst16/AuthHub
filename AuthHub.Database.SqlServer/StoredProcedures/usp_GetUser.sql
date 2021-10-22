CREATE PROCEDURE [dbo].[usp_GetUser]
	@Id uniqueidentifier
AS
	Begin Try
	select * from [User](nolock)
	where Id = @Id
	and DeletedUTC is not null

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
RETURN 0

CREATE PROCEDURE [dbo].[usp_GetPassword]
	@UserId uniqueidentifier
AS
	Begin Try
	select * from [Password](nolock)
	where FK_User = @UserId
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
RETURN 0
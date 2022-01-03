CREATE PROCEDURE [dbo].[usp_GetPassword]
	@userId uniqueidentifier = null,
	@passwordId uniqueidentifier = null
AS
	Begin Try
	If @passwordId is null
	Begin
		select 
			@passwordId = Id
			from Password(nolock)
			where FK_User = @userId
			and DeletedUTC is null
	End

	select * 
	from [Password](nolock)
	where Id = @passwordId
	
	select *
	from Claim(nolock)
	where FK_Password = @passwordId

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
CREATE PROCEDURE [dbo].[usp_GetPassword]
	@authSettingsName nvarchar(200) = null,
	@username nvarchar(200) = null,
	@organizationId uniqueidentifier = null,
	@passwordId uniqueidentifier = null
AS
Begin Transaction Body
	Begin Try

	if @organizationId is null
	Begin
		;throw 10001, 'OrganizationId may not be null', 1
	End

	declare @userId uniqueidentifier;

	If @passwordId is null
	Begin
		
		declare @authSettingsId uniqueidentifier = (
			select top 1 Id
			from AuthSettings(nolock)
			where Name = @authSettingsName
			and FK_Organization = @organizationId
			and DeletedUTC is null
		);

		set @userId = (
			select top 1 Id 
			from [User](nolock)
			where FK_AuthSettings = @authSettingsId
			and Username = @username
			and DeletedUTC is null
		);

		select 
			@passwordId = Id
			from Password(nolock)
			where (
				FK_User = @userId
			)
			and DeletedUTC is null
	End

	select * 
	from [Password](nolock)
	where Id = @passwordId
	
	select *
	from Claim(nolock)
	where FK_Password = @passwordId

Commit Transaction Body
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

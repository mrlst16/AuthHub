CREATE PROCEDURE [dbo].[usp_GetUser]
	@Id uniqueidentifier,
	@organizationId uniqueidentifier,
	@authSettingsName nvarchar(200),
	@userName nvarchar(200)
AS
	Begin Try

	declare @passwordId uniqueidentifier
	declare @authSettingsId uniqueidentifier

	if @Id is null or @id = cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier)
	Begin
		select
			@authSettingsId = ID
		from AuthSettings (nolock)
		where FK_Organization = @organizationId
		and Name = @authSettingsName 
		and DeletedUTC is null

		select 
			@Id = ID
		from [User](nolock)
		where FK_AuthSettings = @authSettingsId
		and Username = @userName
		and DeletedUTC is null
	End
	
	select top 1 u.*, a.FK_Organization as FK_Organization
	into #user
	from [User](nolock) u
	join AuthSettings(nolock) a on u.FK_AuthSettings = a.Id
	where u.Id = @Id
	and u.DeletedUTC is null
	
	select * from #user

	select top 1 
	@passwordId = Id
	from [Password] (nolock) p
	where p.FK_User = @Id
	and DeletedUTC is null

	select *
	from Password(nolock)
	where Id = @passwordId

	select *
	from Claim (nolock) c
	where c.FK_Password = @passwordId
	and DeletedUTC is null

	select top 1 Id as UsersOrganizationId
	from Organization(nolock)
	where Name = (select top 1 FirstName from [User] where Id = (select top 1 id from #user))
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
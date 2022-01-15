CREATE PROCEDURE [dbo].[usp_GetOrganization]
	@id uniqueidentifier = null,
	@name nvarchar(200) = null
AS
Begin Transaction
Begin Try

	if @id is null
	Begin
		set @id = (select Id from Organization where Name = @name)
	End

	select *
	into #organizations
	from Organization(nolock) 
	where (
		Id = @id
		or Name = @name
		)
	and DeletedUTC is null

	select *
	into #authSettings
	from AuthSettings(nolock)
	where FK_Organization = @id
	and DeletedUTC is null

	select *
	into #users
	from [User](nolock)
	where FK_AuthSettings in(
		select Id from #authSettings
	)
	and DeletedUTC is null

	select *
	into #password 
	from Password(nolock)
	where FK_User in (
		select Id from #users
	)
	and DeletedUTC is null

	
	select * from #organizations

	select a.*, s.Value as AuthScheme
	from #authSettings a
	join AuthScheme s on a.FK_AuthScheme = s.Id

	select * from #users

	select * from #password

	select *
	from Claim(nolock)
	where FK_Password in (
		select Id from #password
	)

	select *
	from ClaimsKey(nolock)
	where FK_AuthSettings in (
		select Id from #authSettings
	)
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
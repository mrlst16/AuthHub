CREATE PROCEDURE [dbo].[usp_SavePasswordResetToken]
	@request udt_PasswordResetToken readonly
AS
Begin Transaction
Begin Try


--[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
--	[FK_User] UNIQUEIDENTIFIER NOT NULL,
--    [Count] int not null,
--    [Email] NCHAR(200) NOT NULL, 
--    [ExpirationDate] DATETIME NOT NULL, 
--    [Token] NVARCHAR(6) NOT NULL,
--    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
--    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
--    [DeletedUTC] DATETIME NULL

if (select count(1) from @request) = 0
Begin
	return;
End

declare @userId uniqueidentifier = (select top 1 FK_User from @request)

update PasswordResetToken
set DeletedUTC = getutcdate()
where FK_User = @userId
and DeletedUTC is null

	insert into PasswordResetToken
	(
		Id,
		FK_User,
		Email,
		ExpirationDate,
		Token
	)
	select 
		newid(),
		FK_User,
		Email,
		ExpirationDate,
		Token
	from @request

Commit Transaction
End Try
Begin Catch
	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
	Rollback Transaction
End Catch

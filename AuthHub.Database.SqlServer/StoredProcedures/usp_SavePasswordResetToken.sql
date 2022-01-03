CREATE PROCEDURE [dbo].[usp_SavePasswordResetToken]
	@request udt_PasswordResetToken readonly,
	@claims udt_Claim readonly
AS
Begin Transaction
Begin Try

	merge PasswordResetToken as Target
	using @request as Source
	on (
		Target.Email = Source.Email
		and Target.OrganizationID = Source.OrganizationID
		and Target.AuthSettingsName = Source.AuthSettingsName
		and Target.Count = Source.Count
	)
	when matched
	then update set 
		Target.UserName = Source.UserName,
		Target.ExpirationDate = Source.ExpirationDate,
		Target.Salt = Source.Salt,
		Target.Token = Source.Token,
		Target.IsActive = Source.IsActive,
		Target.Password = Source.Password
	when not matched 
	then insert
	(UserName, Email, OrganizationID, AuthSettingsName, ExpirationDate, Salt, Token, IsActive, Password)
	values (
		Source.UserName,
		Source.Email,
		row_number() over (Partition by Target.OrganizationId, Target.AuthSettingsName, Target.Email),
		Source.AuthSettingsName,
		Source.ExpirationDate,
		Source.Salt,
		Source.Token,
		1,
		Source.Password
	);

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
CREATE PROCEDURE [dbo].[usp_SaveAuthSettings]
	@request udt_AuthSettings readonly,
	@claimsKeys udt_ClaimsKey readonly,
	@flat bit = 0
AS
Begin Transaction
Begin Try

	if (select count(*) from @request) > 1
	Begin
		;throw 50001 , 'Cannot merge more than 1 auth settings at a time', 1
	End
	merge AuthSettings as Target
	using @request as Source
	on (
		Target.Id = Source.Id 
		or
			(
				Target.FK_Organization = Source.FK_Organization
				and Target.Name = Source.Name
				and Target.DeletedUTC is null
			)
		)
	when matched
	then update set
		Target.FK_Organization = Source.FK_Organization,
		Target.FK_AuthScheme = dbo.GetAuthSchemeId(Source.AuthScheme),	
		Target.SaltLength = Source.SaltLength,
		Target.HashLength = Source.HashLength,
		Target.AuthKey = Source.AuthKey,
		Target.Issuer = Source.Issuer,
		Target.ExpirationMinutes = Source.ExpirationMinutes,
		Target.PasswordResetTokenExpirationMinutes = Source.PasswordResetTokenExpirationMinutes,
		Target.ModifiedUTC = getutcdate()
	when not matched
	then insert
	(Id, FK_Organization, Name, FK_AuthScheme, SaltLength, HashLength, 
		Iterations, AuthKey, Issuer, PasswordResetTokenExpirationMinutes, ExpirationMinutes)
	values 
	(
		newid(),
		Source.FK_Organization, Source.Name, dbo.GetAuthSchemeId(Source.AuthScheme), Source.SaltLength, Source.HashLength, 
		Source.Iterations, Source.AuthKey, Source.Issuer, Source.PasswordResetTokenExpirationMinutes, Source.ExpirationMinutes)
	output inserted.Id;

	if @flat = 1
	Begin
		return
	End

	exec usp_SaveClaimsKey @claimsKeys
	
Commit Transaction
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
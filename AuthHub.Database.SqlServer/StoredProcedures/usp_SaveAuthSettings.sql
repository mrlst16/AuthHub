﻿CREATE PROCEDURE [dbo].[usp_SaveAuthSettings]
	@request udt_AuthSettings readonly
AS
Begin Transaction
Begin Try
	merge AuthSettings as Target
	using @request as Source
	on (
		Target.Id = Source.Id 
		or
			(
				Target.FK_Organization = Source.FK_Organization
					and Target.Name = Source.Name
			)
		and Target.DeletedUTC is null
		)
	when matched
	then update set
		Target.FK_AuthScheme = Source.FK_AuthScheme,	
		Target.SaltLength = Source.SaltLength,
		Target.HashLength = Source.HashLength,
		Target.AuthKey = Source.AuthKey,
		Target.Issuer = Source.Issuer,
		Target.PasswordResetTokenExpirationMinutes = Source.PasswordResetTokenExpirationMinutes,
		Target.ModifiedUTC = getutcdate()
	when not matched
	then insert
	(Id, Name, FK_AuthScheme, SaltLength, HashLength, 
		Iterations, AuthKey, Issuer, PasswordResetTokenExpirationMinutes)
	values 
	(newid(), Source.Name, Source.FK_AuthScheme, Source.SaltLength, Source.HashLength, 
		Source.Iterations, Source.AuthKey, Source.Issuer, Source.PasswordResetTokenExpirationMinutes)
	output inserted.Id;

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
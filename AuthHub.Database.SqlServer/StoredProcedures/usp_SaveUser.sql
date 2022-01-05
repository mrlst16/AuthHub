﻿CREATE PROCEDURE [dbo].[usp_SaveUser]
	@request udt_User readonly,
	@organizationId uniqueidentifier
AS
Begin Transaction
Begin Try
	merge [User] as Target
	using @request as Source
	on (
		Target.FK_AuthSettings = Source.FK_AuthSettings
		and Target.Email = Source.Email
		and Target.DeletedUTC is not null
		)
	when matched
	then update set
		Target.Username = Source.Username,
		Target.FK_AuthSettings = Source.FK_AuthSettings,
		Target.Email = Source.Email,
		Target.ModifiedUTC = getutcdate()
	when not matched
	then insert
	(Id, FK_AuthSettings, Username, Email)
	values
	(newid(), Source.FK_AuthSettings, Source.Username, Source.Email)
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
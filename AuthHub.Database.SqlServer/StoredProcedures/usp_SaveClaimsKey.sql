CREATE PROCEDURE [dbo].[usp_SaveClaimsKey]
	@request udt_ClaimsKey readonly
AS
Begin Transaction
Begin Try
	merge ClaimsKey as Target
	using @request as Source
	on (
		Target.Id = Source.Id
		or(
			Target.FK_AuthSettings = Source.FK_AuthSettings
				and Target.Name = Source.Name
				)
		and DeletedUtc is null
		)
	when matched
	then update set
		Target.Name = Source.Name,
		Target.ModifiedUTC = getutcdate()
	when not matched by Target
	then insert
	(Id, FK_AuthSettings, Name)
	values
	(newid(), Source.FK_AuthSettings, Source.Name)
	when not matched by Source then
		delete
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
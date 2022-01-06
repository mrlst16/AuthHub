CREATE PROCEDURE [dbo].[usp_SaveOrganization]
	@request udt_Organization readonly
AS

Begin Transaction
Begin Try
	merge [Organization] as Target
	using @request as Source
	on (
		(
			Target.Id = Source.Id
			or Target.Name = Source.Name
		)
		and Target.DeletedUTC is null
	)
	when matched
	then update set
		Target.Name = Source.Name,
		Target.Email = Source.Email,
		Target.ModifiedUTC = getutcdate()
	when not matched
	then insert
	(Id, Name, Email)
	values 
	(newid(), Source.Name, Source.Email)
	Output inserted.Id;
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
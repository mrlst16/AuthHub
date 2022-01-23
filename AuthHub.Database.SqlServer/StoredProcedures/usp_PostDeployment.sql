CREATE   PROCEDURE [dbo].[usp_PostDeployment]
	@commit bit = 0
AS 
Begin Transaction Body
Begin Try
--Seed static values
declare @organizationId uniqueidentifier = '0B674AC4-7079-4AD7-830A-C41CD6AB5204'
declare @authSettingsId uniqueidentifier = '6CE12DA2-CB73-4F0B-B9F0-46051621B3C6'

declare @authSchemes table (
	id uniqueidentifier not null,
	Name nvarchar(200) not null, 
	Value nvarchar(200) not null
);
insert into @authSchemes
values
('b696fb1e-f823-4b59-a8b0-ca68a93a7ab4', 'JWT', 1)

merge AuthScheme as Target
using @authSchemes as Source
on (
	Target.Id = Source.Id
	or Target.[Name] = Source.[Name]
	or Target.Value = Source.Value
)
when not matched then insert
values
(Source.Id, Source.Name, Source.Value);


declare @request_var udt_Organization
insert into @request_var 
values
(@organizationId, 'audder', 'mrlst16@mail.rmu.edu')
exec dbo.usp_SaveOrganization @request=@request_var

declare @authSettings udt_AuthSettings
insert into @authSettings
(Id, FK_Organization, Name, AuthScheme, SaltLength, HashLength, Iterations, [AuthKey], Issuer, PasswordResetTokenExpirationMinutes)
values
(@authSettingsId, @organizationId, 'audder_clients', 1, 8, 8, 10, 'this is my custom Secret key for authentication', 'Issuer', 60)
exec usp_SaveAuthSettings @authSettings, @flat = 1

SELECT 'ClaimsKeys after exec usp_SaveAuthSettings @authSettings' as [Table], * 
from ClaimsKey(nolock)

declare @claimsKeys udt_ClaimsKey
insert into @claimsKeys
values
('3aacb46c-418d-4f6b-92c6-6580c473e9c6', '6CE12DA2-CB73-4F0B-B9F0-46051621B3C6', 'Name'),
('fc77aa09-1156-4040-b0e2-72b06ba5513b', '6CE12DA2-CB73-4F0B-B9F0-46051621B3C6', 'Role')
exec usp_SaveClaimsKey @claimsKeys

if @commit = 0
	Begin
		select 'Rolling Back'
		Rollback Transaction Body
		Return
	End

Commit Transaction Body
End Try
Begin Catch
	Rollback Transaction Body

	SELECT
		ERROR_NUMBER() AS ErrorNumber,
		ERROR_STATE() AS ErrorState,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMessage;
End Catch
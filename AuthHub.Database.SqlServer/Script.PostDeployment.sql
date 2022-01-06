/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
declare @request_var udt_Organization
insert into @request_var select '0B674AC4-7079-4AD7-830A-C41CD6AB5204', 'audder', 'mrlst16@mail.rmu.edu'
exec usp_SaveOrganization @request=@request_var

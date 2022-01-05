CREATE TABLE [dbo].[AuthSettings]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] nvarchar(200) NOT NULL,
    [FK_Organization] UNIQUEIDENTIFIER NOT NULL, 
    [FK_AuthScheme] UNIQUEIDENTIFIER NOT NULL,
    [SaltLength] INT NOT NULL, 
    [HashLength] INT NOT NULL, 
    [Iterations] INT NOT NULL, 
    [AuthKey] NVARCHAR(100) NOT NULL, 
    [Issuer] NCHAR(10) NOT NULL, 
    [PasswordResetTokenExpirationMinutes] INT NOT NULL, 
    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
    [DeletedUTC] DATETIME NULL, 
    CONSTRAINT [FK_AuthSettings_ToOrganizationId] FOREIGN KEY ([FK_Organization]) REFERENCES Organization(Id)
)

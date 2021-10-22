CREATE TABLE [dbo].[ClaimsKey]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FK_AuthSettings] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
    [DeletedUTC] DATETIME NULL, 
    CONSTRAINT [FK_ClaimsKey_ToAuthSettings] FOREIGN KEY ([FK_AuthSettings]) REFERENCES AuthSettings(Id)
)

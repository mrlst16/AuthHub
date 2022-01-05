CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FK_AuthSettings] UNIQUEIDENTIFIER NOT NULL, 
    [FirstName] NVARCHAR(200) NOT NULL, 
    [LastName] NVARCHAR(200) NULL, 
    [Email] NVARCHAR(300) NOT NULL, 
    [Username] NCHAR(200) NOT NULL, 
    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
    [DeletedUTC] DATETIME NULL, 
    CONSTRAINT [FK_User_ToAuthSettings] FOREIGN KEY ([FK_AuthSettings]) REFERENCES AuthSettings(Id)
)

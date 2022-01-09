CREATE TABLE [dbo].[Password]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FK_User] UNIQUEIDENTIFIER NOT NULL, 
    [UserName] NCHAR(200) NOT NULL, 
    [PasswordHash] VARBINARY(MAX) NULL, 
    [Salt] VARBINARY(MAX) NULL, 
    [HashLength] INT NOT NULL, 
    [Iterations] INT NOT NULL default 10, 
    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
    [DeletedUTC] DATETIME NULL, 
    CONSTRAINT [FK_Password_ToUser] FOREIGN KEY (FK_User) REFERENCES [User](Id)
)

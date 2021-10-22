﻿CREATE TABLE [dbo].[Password]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FK_User] UNIQUEIDENTIFIER NOT NULL, 
    [UserName] NCHAR(200) NOT NULL, 
    [PasswordHash] VARBINARY(MAX) NOT NULL, 
    [Salt] VARBINARY(MAX) NOT NULL, 
    [HashLength] INT NOT NULL, 
    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
    [DeletedUTC] DATETIME NULL, 
    CONSTRAINT [FK_Password_ToUser] FOREIGN KEY (FK_User) REFERENCES [User](Id)
)
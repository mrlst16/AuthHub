CREATE TABLE [dbo].[Claim]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FK_Password] UNIQUEIDENTIFIER NOT NULL, 
    [Key] NVARCHAR(200) NOT NULL, 
    [Value] NVARCHAR(200) NOT NULL, 
    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
    [DeletedUTC] DATETIME NULL, 
    CONSTRAINT [FK_Claim_ToUser] FOREIGN KEY ([FK_Password]) REFERENCES [Password](Id)
)

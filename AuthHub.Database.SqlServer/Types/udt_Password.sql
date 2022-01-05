CREATE TYPE [dbo].[udt_Password] AS TABLE
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [FK_User] UNIQUEIDENTIFIER NOT NULL, 
    [UserName] NCHAR(200) NOT NULL, 
    [PasswordHash] VARBINARY(MAX) NOT NULL, 
    [Salt] VARBINARY(MAX) NOT NULL, 
    [HashLength] INT NOT NULL,
    [Iterations] INT NOT NULL default 0
)
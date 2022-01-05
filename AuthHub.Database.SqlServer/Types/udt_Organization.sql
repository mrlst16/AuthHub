CREATE TYPE [dbo].[udt_Organization] AS TABLE
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(200) NOT NULL,
	[Email] nvarchar(200) not null
)

﻿CREATE TYPE [dbo].[udt_Claim] AS TABLE
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
    [FK_Password] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Value] NVARCHAR(200) NOT NULL
)
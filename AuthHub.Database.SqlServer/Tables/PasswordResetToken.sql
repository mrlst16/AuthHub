CREATE TABLE [dbo].[PasswordResetToken]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Count] int not null,
	[UserName] nvarchar(200) NOT NULL, 
    [Email] NCHAR(200) NOT NULL, 
    [OrganizationID] UNIQUEIDENTIFIER NOT NULL, 
    [AuthSettingsName] NCHAR(200) NOT NULL, 
    [ExpirationDate] DATETIME NOT NULL, 
    [Salt] VARBINARY(MAX) NOT NULL, 
    [Token] VARBINARY(MAX) NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [Password] VARBINARY(MAX) NOT NULL
)
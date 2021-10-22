CREATE TYPE [dbo].[udt_AuthSettings] AS TABLE
(
	Id uniqueidentifier,
	FK_Organization uniqueidentifier,
	Name nvarchar(200),
	FK_AuthScheme int,
	SaltLength int,
	HashLength int,
	Iterations int,
	[Key] nvarchar(max),
	Issuer nvarchar(max),
	PasswordResetTokenExpirationMinutes int
)

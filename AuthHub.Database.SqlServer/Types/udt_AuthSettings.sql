CREATE TYPE [dbo].[udt_AuthSettings] AS TABLE
(
	Id uniqueidentifier,
	FK_Organization uniqueidentifier,
	Name nvarchar(200),
	FK_AuthScheme uniqueidentifier,
	SaltLength int,
	HashLength int,
	Iterations int,
	AuthKey nvarchar(100),
	Issuer nvarchar(max),
	PasswordResetTokenExpirationMinutes int
)

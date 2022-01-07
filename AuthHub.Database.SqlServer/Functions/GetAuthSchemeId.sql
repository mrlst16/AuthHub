CREATE FUNCTION GetAuthSchemeId
(
	@value int
)
RETURNS uniqueidentifier
AS
BEGIN
	
	declare @result uniqueidentifier
	select top 1 
		@result = Id
	from AuthScheme
	where Value = @value

	RETURN @result
END
GO
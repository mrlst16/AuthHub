CREATE   FUNCTION [dbo].[IsValidGuid]
(
	@value uniqueidentifier
)
RETURNS bit
AS
BEGIN
	declare @emptyGuid uniqueidentifier = cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier)
	if @value is null or @value = @emptyGuid
	Begin
		return 0
	End
	return 1
END
CREATE FUNCTION UUIDNotEmpty
(
	@guid uniqueidentifier
)
RETURNS bit
AS
BEGIN
	if @guid is null or @guid = cast('00000000-0000-0000-0000-000000000000' as uniqueidentifier)
	Begin
		return 0;
	end;
	else
	Begin
		return 1;
	End
	return 0
END

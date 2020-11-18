alter procedure [dbo].[GetAvailableRooms]
    -- Add the parameters for the stored procedure here
    @DateFrom datetime = null,
	@DateTo	datetime = null
as
begin
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    set nocount on;

    -- Insert statements for procedure here
	select r.*
	from Room r with (nolock)
		left outer join Booking b with (nolock) on r.RoomId = b.RoomId
												and b.DateFrom <= @DateTo and b.DateTo >= @DateFrom
	where b.BookingId is null
end
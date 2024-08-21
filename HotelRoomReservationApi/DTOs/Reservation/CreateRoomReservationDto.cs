namespace HotelRoomReservationApi.DTOs.Reservation
{
    public class CreateRoomReservationDto
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

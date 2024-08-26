namespace HotelRoomReservationApi.DTOs.Reservation
{
    public class CreateRoomReservationDto
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cijena { get; set; }
        public int BrojOsoba { get; set; }
    }
}

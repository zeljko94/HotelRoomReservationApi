namespace HotelRoomReservationApi.DTOs.Rooms
{
    public class RoomDto
    {
        public string Id { get; set; }
        public int BrojKreveta { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string ThumbnailImg { get; set; }
        public decimal Cijena { get; set; }
    }
}

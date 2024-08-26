using Microsoft.AspNetCore.Identity;

namespace HotelRoomReservationApi.Models
{
    public class RoomReservation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cijena { get; set; } 
        public int BrojOsoba { get; set; }
    }
}

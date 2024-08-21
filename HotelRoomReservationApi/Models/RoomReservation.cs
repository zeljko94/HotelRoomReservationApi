using Microsoft.AspNetCore.Identity;

namespace HotelRoomReservationApi.Models
{
    public class RoomReservation : IdentityUser
    {
        public string Id { get; set; }
        public string RoomName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

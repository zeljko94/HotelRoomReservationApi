using Microsoft.AspNetCore.Identity;

namespace HotelRoomReservationApi.Models
{
    public class User : IdentityUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace HotelRoomReservationApi.Models
{
    public class Soba
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int BrojKreveta { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string ThumbnailImg { get; set; }
        public decimal Cijena { get; set; }
    }
}

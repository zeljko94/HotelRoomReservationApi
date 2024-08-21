using RoomReservationApi.Data;
using HotelRoomReservationApi.Models;
using HotelRoomReservationApi.Repositories.Interfaces;

namespace RoomReservationApi.Repositories
{
    public class SobaRepository : Repository<Soba>, ISobaRepository
    {
        public SobaRepository(ReservationContext context) : base(context)
        {
        }
    }

    public interface ISobaRepository : IRepository<Soba>
    {
    }
}

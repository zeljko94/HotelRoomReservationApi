using RoomReservationApi.Data;
using HotelRoomReservationApi.Models;
using HotelRoomReservationApi.Repositories.Interfaces;

namespace RoomReservationApi.Repositories
{
    public class RoomReservationRepository : Repository<RoomReservation>, IRoomReservationRepository
    {
        public RoomReservationRepository(ReservationContext context) : base(context)
        {
        }
    }

    public interface IRoomReservationRepository : IRepository<RoomReservation>
    {
    }
}

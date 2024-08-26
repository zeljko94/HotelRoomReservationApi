using RoomReservationApi.Data;
using HotelRoomReservationApi.Models;
using HotelRoomReservationApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RoomReservationApi.Repositories
{
    public class SobaRepository : Repository<Soba>, ISobaRepository
    {
        public SobaRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<List<Soba>> GetSobeByIdsAsync(List<string> ids)
        {
            return await _context.Sobe
                .Where(k => ids.Contains(k.Id))
                .ToListAsync();
        }
    }

    public interface ISobaRepository : IRepository<Soba>
    {
        Task<List<Soba>> GetSobeByIdsAsync(List<string> ids);
    }
}

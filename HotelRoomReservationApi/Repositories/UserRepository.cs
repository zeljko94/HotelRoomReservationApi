using RoomReservationApi.Data;
using HotelRoomReservationApi.Models;
using HotelRoomReservationApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RoomReservationApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}

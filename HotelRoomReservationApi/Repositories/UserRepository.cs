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

        public async Task<List<User>> GetKorisniciByIdsAsync(List<string> ids)
        {
            return await _context.Users
                .Where(k => ids.Contains(k.Id))
                .ToListAsync();
        }

        public async Task DeleteMultipleKorisniciAsync(List<User> korisnici)
        {
            _context.Users.RemoveRange(korisnici);
            await _context.SaveChangesAsync();
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);

        Task<List<User>> GetKorisniciByIdsAsync(List<string> ids);
        Task DeleteMultipleKorisniciAsync(List<User> korisnici);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelRoomReservationApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteRange(List<T> entities);
        Task<bool> SaveChangesAsync();
    }
}
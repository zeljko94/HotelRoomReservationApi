using HotelRoomReservationApi.DTOs.User;
using HotelRoomReservationApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(string id);
        Task AddUserAsync(CreateUserDto userDto);
        Task<bool> UpdateUserAsync(string id, UserDto userDto);
        Task<bool> DeleteUserAsync(string id);
        Task DeleteMultipleKorisniciAsync(List<string> ids);
    }
}

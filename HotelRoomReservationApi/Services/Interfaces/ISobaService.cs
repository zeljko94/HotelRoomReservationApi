using HotelRoomReservationApi.DTOs.Rooms;
using HotelRoomReservationApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public interface ISobaService
    {
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
        Task<RoomDto> GetRoomByIdAsync(string id);
        Task AddRoomAsync(CreateRoomDto roomDto);
        Task<bool> UpdateRoomAsync(string id, RoomDto roomDto);
        Task<bool> DeleteRoomAsync(string id);
        Task DeleteRange(List<string> ids);
    }
}

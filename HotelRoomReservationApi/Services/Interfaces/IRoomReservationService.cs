using HotelRoomReservationApi.DTOs.Reservation;
using HotelRoomReservationApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public interface IRoomReservationService
    {
        Task<IEnumerable<RoomReservationDto>> GetAllReservationsAsync();
        Task<RoomReservationDto> GetReservationByIdAsync(string id);
        Task AddReservationAsync(CreateRoomReservationDto reservationDto);
        Task<bool> UpdateReservationAsync(string id, RoomReservationDto reservationDto);
        Task<bool> DeleteReservationAsync(string id);
    }
}

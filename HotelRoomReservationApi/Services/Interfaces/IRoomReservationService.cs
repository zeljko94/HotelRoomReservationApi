using HotelRoomReservationApi.DTOs.Reservation;
using HotelRoomReservationApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public interface IRoomReservationService
    {
        Task<IEnumerable<RoomReservationDto>> GetAllReservationsAsync();
        Task<RoomReservationDto> GetReservationByIdAsync(int id);
        Task AddReservationAsync(CreateRoomReservationDto reservationDto);
        Task<bool> UpdateReservationAsync(int id, RoomReservationDto reservationDto);
        Task<bool> DeleteReservationAsync(int id);
    }
}

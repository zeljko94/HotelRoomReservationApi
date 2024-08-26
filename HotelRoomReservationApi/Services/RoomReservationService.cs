using AutoMapper;
using HotelRoomReservationApi.DTOs.Reservation;
using HotelRoomReservationApi.Models;
using RoomReservationApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public class RoomReservationService : IRoomReservationService
    {
        private readonly IRoomReservationRepository _reservationsRepository;
        private readonly IMapper _mapper;

        public RoomReservationService(IRoomReservationRepository reservationsRepository, IMapper mapper)
        {
            _reservationsRepository = reservationsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomReservationDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomReservationDto>>(reservations);
        }

        public async Task<RoomReservationDto> GetReservationByIdAsync(string id)
        {
            var reservation = await _reservationsRepository.GetByIdAsync(id);
            return _mapper.Map<RoomReservationDto>(reservation);
        }

        public async Task AddReservationAsync(CreateRoomReservationDto reservationDto)
        {
            var reservation = _mapper.Map<RoomReservation>(reservationDto);
            await _reservationsRepository.AddAsync(reservation);
            await _reservationsRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateReservationAsync(string id, RoomReservationDto reservationDto)
        {
            var reservation = await _reservationsRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }

            _mapper.Map(reservationDto, reservation);
            _reservationsRepository.Update(reservation);
            return await _reservationsRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteReservationAsync(string id)
        {
            var reservation = await _reservationsRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }

            _reservationsRepository.Delete(reservation);
            return await _reservationsRepository.SaveChangesAsync();
        }
    }
}

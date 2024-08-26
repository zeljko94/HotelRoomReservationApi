using AutoMapper;
using HotelRoomReservationApi.DTOs.Rooms;
using HotelRoomReservationApi.Models;
using RoomReservationApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public class SobaService : ISobaService
    {
        private readonly ISobaRepository _roomRepository;
        private readonly IMapper _mapper;

        public SobaService(ISobaRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetRoomByIdAsync(string id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task AddRoomAsync(CreateRoomDto roomDto)
        {
            var room = _mapper.Map<Soba>(roomDto);
            await _roomRepository.AddAsync(room);
            await _roomRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateRoomAsync(string id, RoomDto roomDto)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return false;
            }

            _mapper.Map(roomDto, room);
            _roomRepository.Update(room);
            return await _roomRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoomAsync(string id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return false;
            }

            _roomRepository.Delete(room);
            return await _roomRepository.SaveChangesAsync();
        }

        public async Task DeleteRange(List<string> ids)
        {
            var korisniciToDelete = await _roomRepository.GetSobeByIdsAsync(ids);

            if (korisniciToDelete.Any())
            {
                await _roomRepository.DeleteRange(korisniciToDelete);
            }
        }
    }
}

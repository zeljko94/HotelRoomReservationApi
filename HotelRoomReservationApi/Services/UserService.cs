using AutoMapper;
using HotelRoomReservationApi.DTOs.User;
using HotelRoomReservationApi.Models;
using Microsoft.EntityFrameworkCore;
using RoomReservationApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task AddUserAsync(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateUserAsync(string id, UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            _mapper.Map(userDto, user);
            _userRepository.Update(user);
            return await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            _userRepository.Delete(user);
            return await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteMultipleKorisniciAsync(List<string> ids)
        {
            var korisniciToDelete = await _userRepository.GetKorisniciByIdsAsync(ids);

            if (korisniciToDelete.Any())
            {
                await _userRepository.DeleteMultipleKorisniciAsync(korisniciToDelete);
            }
        }
    }
}

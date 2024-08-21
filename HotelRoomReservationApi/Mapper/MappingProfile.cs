using AutoMapper;
using HotelRoomReservationApi.DTOs.User;
using HotelRoomReservationApi.Models;

namespace RoomReservationApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UserDto, User>();
            // Add mappings for other DTOs and models as needed
        }
    }
}

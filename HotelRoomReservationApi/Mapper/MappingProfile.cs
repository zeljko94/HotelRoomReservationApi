using AutoMapper;
using HotelRoomReservationApi.DTOs.Reservation;
using HotelRoomReservationApi.DTOs.Rooms;
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

            CreateMap<Soba, RoomDto>();
            CreateMap<CreateRoomDto, Soba>();
            CreateMap<RoomDto, Soba>();

            CreateMap<RoomReservation, RoomReservationDto>();
            CreateMap<CreateRoomReservationDto, RoomReservation>();
            CreateMap<RoomReservationDto, RoomReservation>();
        }
    }
}

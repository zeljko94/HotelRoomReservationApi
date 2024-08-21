using HotelRoomReservationApi.DTOs.Auth;

namespace HotelRoomReservationApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto loginDto);
        Task<bool> Register(RegisterDto registerDto);
        Task Logout();
    }
}

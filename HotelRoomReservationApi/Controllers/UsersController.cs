using HotelRoomReservationApi.DTOs.Auth;
using HotelRoomReservationApi.DTOs.User;
using HotelRoomReservationApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RoomReservationApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(RegisterDto userDto)
        {
            var result = await _authService.Register(userDto);
            if (!result)
            {
                return BadRequest(new { message = "User already exists" });
            }

            return Ok(new { message = "User added successfully!" });
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, UserDto userDto)
        {
            var result = await _userService.UpdateUserAsync(id, userDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteMultipleKorisnici([FromBody] List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return BadRequest("No IDs provided.");
            }

            try
            {
                await _userService.DeleteMultipleKorisniciAsync(ids);
                return Ok(new { message = "Korisnici successfully deleted." });
            }
            catch (Exception ex)
            {
                // Log the exception (not shown)
                return StatusCode(500, "An error occurred while deleting korisnici.");
            }
        }
    }
}

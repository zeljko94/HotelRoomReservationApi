using HotelRoomReservationApi.DTOs.Rooms;
using Microsoft.AspNetCore.Mvc;
using RoomReservationApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobeController : ControllerBase
    {
        private readonly ISobaService _sobaService;

        public SobeController(ISobaService sobaService)
        {
            _sobaService = sobaService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            return Ok(await _sobaService.GetAllRoomsAsync());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _sobaService.GetRoomByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<RoomDto>> PostRoom(CreateRoomDto roomDto)
        {
            await _sobaService.AddRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoom), new { id = roomDto.Id }, roomDto);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDto roomDto)
        {
            var result = await _sobaService.UpdateRoomAsync(id, roomDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _sobaService.DeleteRoomAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

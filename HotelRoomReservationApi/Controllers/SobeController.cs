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

        // GET: api/Sobe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            return Ok(await _sobaService.GetAllRoomsAsync());
        }

        // GET: api/Sobe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(string id)
        {
            var room = await _sobaService.GetRoomByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/Sobe
        [HttpPost]
        public async Task<ActionResult<RoomDto>> PostRoom(CreateRoomDto roomDto)
        {
            await _sobaService.AddRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoom), new { id = roomDto.Id }, roomDto);
        }

        // PUT: api/Sobe/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(string id, RoomDto roomDto)
        {
            var result = await _sobaService.UpdateRoomAsync(id, roomDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Sobe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            var result = await _sobaService.DeleteRoomAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteRange([FromBody] List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return BadRequest("No IDs provided.");
            }

            try
            {
                await _sobaService.DeleteRange(ids);
                return Ok(new { message = "Sobe successfully deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting sobe.");
            }
        }
    }
}

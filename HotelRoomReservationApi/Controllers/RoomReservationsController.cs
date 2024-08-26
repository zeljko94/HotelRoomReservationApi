using HotelRoomReservationApi.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;
using RoomReservationApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomReservationsController : ControllerBase
    {
        private readonly IRoomReservationService _reservationsService;

        public RoomReservationsController(IRoomReservationService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        // GET: api/RoomReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomReservationDto>>> GetReservations()
        {
            var reservations = await _reservationsService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        // GET: api/RoomReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomReservationDto>> GetReservation(string id)
        {
            var reservation = await _reservationsService.GetReservationByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // POST: api/RoomReservations
        [HttpPost]
        public async Task<ActionResult<RoomReservationDto>> PostReservation(CreateRoomReservationDto reservationDto)
        {
            await _reservationsService.AddReservationAsync(reservationDto);
            return CreatedAtAction(nameof(GetReservation), new { id = reservationDto.RoomId }, reservationDto);
        }

        // PUT: api/RoomReservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(string id, RoomReservationDto reservationDto)
        {
            var result = await _reservationsService.UpdateReservationAsync(id, reservationDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/RoomReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            var result = await _reservationsService.DeleteReservationAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

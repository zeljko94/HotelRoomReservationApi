﻿namespace HotelRoomReservationApi.DTOs.Reservation
{
    public class RoomReservationDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

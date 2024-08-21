using HotelRoomReservationApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RoomReservationApi.Data
{
    public class ReservationContext : IdentityDbContext<User>
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Soba> Sobe { get; set; }
    }
}
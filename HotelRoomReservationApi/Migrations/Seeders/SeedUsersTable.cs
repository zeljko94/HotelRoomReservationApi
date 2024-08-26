using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomReservationApi.Migrations.Seeders
{
    public class SeedUsersTable
    {
        public static void SeedInitialUsers(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[]
                {
                    "Id", "Username", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed",
                    "PasswordHash", "Password", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed",
                    "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount", "Name", "LastName", "Role"
                },
                values: new object[,]
                {
                    {
                        "2ee8a5be-166b-48eb-b6e2-4e0ef6775298", "admin1", "admin1", "ADMIN1", "admin1@gmail.com", "ADMIN1@GMAIL.COM", true,
                        "", "AQAAAAEAACcQAAAAEKRyG/suVBHhhaXK+PXizBv+ZfgPZGYSsrumbU+upRwnDZwk9AWvrjuwxisFTYMhiw==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        null, true, false, null, false, 0, "Admin", "User", "admin"
                    },
                    {
                        "8939e7de-810f-4add-9645-4459b625b773", "test1", "test1", "TEST1", "test1@gmail.com", "TEST1@GMAIL.COM", true,
                        "", "AQAAAAEAACcQAAAAEKRyG/suVBHhhaXK+PXizBv+ZfgPZGYSsrumbU+upRwnDZwk9AWvrjuwxisFTYMhiw==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        null, true, false, null, false, 0, "Test", "User", "user"
                    },
                    {
                        "8655da7f-1d36-4c2b-9cef-8e6aa16be382", "test2", "test2", "TEST2", "test2@gmail.com", "TEST2@GMAIL.COM", true,
                        "", "AQAAAAEAACcQAAAAEKRyG/suVBHhhaXK+PXizBv+ZfgPZGYSsrumbU+upRwnDZwk9AWvrjuwxisFTYMhiw==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        null, true, false, null, false, 0, "Test", "User", "user"
                    }
                }
            );
        }

    }
}

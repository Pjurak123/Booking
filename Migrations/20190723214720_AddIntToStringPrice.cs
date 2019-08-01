using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations
{
    public partial class AddIntToStringPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "ClientAppointments",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ClientAppointments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

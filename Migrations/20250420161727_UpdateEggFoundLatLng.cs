using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EggHuntApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEggFoundLatLng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "EggsFound",
                type: "float(53)", // Use float(53) for double precision
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "EggsFound",
                type: "float(53)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverse the changes if needed for downgrading (optional but recommended)
            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "EggsFound",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(53)");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "EggsFound",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(53)");
        }
    }
}

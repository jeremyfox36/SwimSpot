using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Api.Migrations
{
    public partial class updatesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SwimmingSpots",
                keyColumn: "SwimmingSpotId",
                keyValue: 1,
                column: "SwimmingSpotName",
                value: "Stantling Craigs");

            migrationBuilder.UpdateData(
                table: "SwimmingSpots",
                keyColumn: "SwimmingSpotId",
                keyValue: 2,
                column: "SwimmingSpotName",
                value: "Gladhouse Reservoir");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SwimmingSpots",
                keyColumn: "SwimmingSpotId",
                keyValue: 1,
                column: "SwimmingSpotName",
                value: "Gladhouse Reservoir");

            migrationBuilder.UpdateData(
                table: "SwimmingSpots",
                keyColumn: "SwimmingSpotId",
                keyValue: 2,
                column: "SwimmingSpotName",
                value: "Stantling Craigs");
        }
    }
}

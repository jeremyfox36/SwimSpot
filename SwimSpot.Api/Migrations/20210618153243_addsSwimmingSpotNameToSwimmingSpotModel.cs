using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Api.Migrations
{
    public partial class addsSwimmingSpotNameToSwimmingSpotModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SwimmingSpotName",
                table: "SwimmingSpots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SwimmingSpotName",
                table: "SwimmingSpots");
        }
    }
}

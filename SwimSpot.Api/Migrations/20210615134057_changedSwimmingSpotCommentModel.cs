using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Api.Migrations
{
    public partial class changedSwimmingSpotCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SwimmingSpotComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SwimmingSpotComments",
                keyColumn: "SwimmingSpotCommentId",
                keyValue: 1,
                column: "UserName",
                value: "Jem");

            migrationBuilder.UpdateData(
                table: "SwimmingSpotComments",
                keyColumn: "SwimmingSpotCommentId",
                keyValue: 2,
                column: "UserName",
                value: "Jem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SwimmingSpotComments");
        }
    }
}

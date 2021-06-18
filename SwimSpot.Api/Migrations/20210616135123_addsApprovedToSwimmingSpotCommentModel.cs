using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Api.Migrations
{
    public partial class addsApprovedToSwimmingSpotCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "SwimmingSpotComments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "SwimmingSpotComments");
        }
    }
}

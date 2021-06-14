using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Api.Migrations
{
    public partial class MoreFakeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SwimmingSpots",
                columns: new[] { "SwimmingSpotId", "Latitude", "Longitude" },
                values: new object[] { 2, 55.77398808982048m, -3.1221541644140895m });

            migrationBuilder.InsertData(
                table: "SwimmingSpotComments",
                columns: new[] { "SwimmingSpotCommentId", "CommentDate", "Content", "SwimDate", "SwimmingSpotId", "UserId", "WaterTemp" },
                values: new object[] { 2, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swam around the island", new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SwimmingSpotComments",
                keyColumn: "SwimmingSpotCommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SwimmingSpots",
                keyColumn: "SwimmingSpotId",
                keyValue: 2);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SwimmingSpots",
                columns: table => new
                {
                    SwimmingSpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<decimal>(type: "decimal(17,15)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(17,15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingSpots", x => x.SwimmingSpotId);
                });

            migrationBuilder.CreateTable(
                name: "SwimmingSpotComments",
                columns: table => new
                {
                    SwimmingSpotCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwimmingSpotId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaterTemp = table.Column<int>(type: "int", nullable: false),
                    SwimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingSpotComments", x => x.SwimmingSpotCommentId);
                    table.ForeignKey(
                        name: "FK_SwimmingSpotComments_SwimmingSpots_SwimmingSpotId",
                        column: x => x.SwimmingSpotId,
                        principalTable: "SwimmingSpots",
                        principalColumn: "SwimmingSpotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SwimmingSpots",
                columns: new[] { "SwimmingSpotId", "Latitude", "Longitude" },
                values: new object[] { 1, 55.6455217723385m, -2.9060585301065363m });

            migrationBuilder.InsertData(
                table: "SwimmingSpotComments",
                columns: new[] { "SwimmingSpotCommentId", "CommentDate", "Content", "SwimDate", "SwimmingSpotId", "UserId", "WaterTemp" },
                values: new object[] { 1, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swam along west shore with Doug", new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 20 });

            migrationBuilder.CreateIndex(
                name: "IX_SwimmingSpotComments_SwimmingSpotId",
                table: "SwimmingSpotComments",
                column: "SwimmingSpotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwimmingSpotComments");

            migrationBuilder.DropTable(
                name: "SwimmingSpots");
        }
    }
}

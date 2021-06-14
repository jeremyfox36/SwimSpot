using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwimSpot.Data.Migrations
{
    public partial class AddSwimSpotAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SwimSpots",
                columns: table => new
                {
                    SwimSpotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimSpots", x => x.SwimSpotId);
                });

            migrationBuilder.CreateTable(
                name: "SwimSpotComments",
                columns: table => new
                {
                    SwimSpotCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwimSpotId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    WaterTemp = table.Column<int>(nullable: false),
                    SwimDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimSpotComments", x => x.SwimSpotCommentId);
                    table.ForeignKey(
                        name: "FK_SwimSpotComments_SwimSpots_SwimSpotId",
                        column: x => x.SwimSpotId,
                        principalTable: "SwimSpots",
                        principalColumn: "SwimSpotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwimSpotComments_SwimSpotId",
                table: "SwimSpotComments",
                column: "SwimSpotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwimSpotComments");

            migrationBuilder.DropTable(
                name: "SwimSpots");
        }
    }
}

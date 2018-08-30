using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoadMapServer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoadMap",
                columns: table => new
                {
                    GroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadMap", x => x.GroupName);
                });

            migrationBuilder.CreateTable(
                name: "MileStone",
                columns: table => new
                {
                    MileStoneName = table.Column<string>(nullable: false),
                    MileStoneIsCompleted = table.Column<bool>(nullable: false),
                    MileStoneTimeStamp = table.Column<DateTime>(nullable: false),
                    RoadMapGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileStone", x => x.MileStoneName);
                    table.ForeignKey(
                        name: "FK_MileStone_RoadMap_RoadMapGroupName",
                        column: x => x.RoadMapGroupName,
                        principalTable: "RoadMap",
                        principalColumn: "GroupName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MileStone_RoadMapGroupName",
                table: "MileStone",
                column: "RoadMapGroupName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MileStone");

            migrationBuilder.DropTable(
                name: "RoadMap");
        }
    }
}

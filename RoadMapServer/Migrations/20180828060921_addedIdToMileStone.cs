using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoadMapServer.Migrations
{
    public partial class addedIdToMileStone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MileStone",
                table: "MileStone");

            migrationBuilder.AlterColumn<string>(
                name: "MileStoneName",
                table: "MileStone",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MileStoneId",
                table: "MileStone",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MileStone",
                table: "MileStone",
                column: "MileStoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MileStone",
                table: "MileStone");

            migrationBuilder.DropColumn(
                name: "MileStoneId",
                table: "MileStone");

            migrationBuilder.AlterColumn<string>(
                name: "MileStoneName",
                table: "MileStone",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MileStone",
                table: "MileStone",
                column: "MileStoneName");
        }
    }
}

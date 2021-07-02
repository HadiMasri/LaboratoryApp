using Microsoft.EntityFrameworkCore.Migrations;

namespace Laboratory.DAL.Migrations
{
    public partial class RangePropertyDeletedFromTestRangeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Range",
                table: "TestRanges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Range",
                table: "TestRanges",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }
    }
}

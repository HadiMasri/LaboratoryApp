using Microsoft.EntityFrameworkCore.Migrations;

namespace Laboratory.DAL.Migrations
{
    public partial class GenderRemovedFromTestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Gender_GenderId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_GenderId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Tests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_GenderId",
                table: "Tests",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Gender_GenderId",
                table: "Tests",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");
        }
    }
}

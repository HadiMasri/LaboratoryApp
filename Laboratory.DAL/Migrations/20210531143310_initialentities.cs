using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laboratory.DAL.Migrations
{
    public partial class initialentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNr = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", maxLength: 4, nullable: false),
                    AppearName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    ArriveTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomNr = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    PhoneNr = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromAge = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ToAge = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Range = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    LowFrom = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    HighFrom = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRanges_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestRanges_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "patient_Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_patient_Tests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patient_Tests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hematology" },
                    { 2, "Chemistry" },
                    { 3, "Hormones" },
                    { 4, "Fluid" },
                    { 5, "Urine" },
                    { 6, "Stool" },
                    { 7, "Semen" },
                    { 8, "Serology" },
                    { 9, "Autoimmune" },
                    { 10, "Cancer" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mr" },
                    { 2, "Mrs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_patient_Tests_PatientId",
                table: "patient_Tests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_Tests_TestId",
                table: "patient_Tests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TitleId",
                table: "Patients",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRanges_GenderId",
                table: "TestRanges",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRanges_TestId",
                table: "TestRanges",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CategoryId",
                table: "Tests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_GenderId",
                table: "Tests",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "Labos");

            migrationBuilder.DropTable(
                name: "patient_Tests");

            migrationBuilder.DropTable(
                name: "TestRanges");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Laboratory.DAL.Migrations
{
    public partial class PatientTestTableNameEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_Tests_Patients_PatientId",
                table: "patient_Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_Tests_Tests_TestId",
                table: "patient_Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patient_Tests",
                table: "patient_Tests");

            migrationBuilder.RenameTable(
                name: "patient_Tests",
                newName: "Patient_Tests");

            migrationBuilder.RenameIndex(
                name: "IX_patient_Tests_TestId",
                table: "Patient_Tests",
                newName: "IX_Patient_Tests_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_patient_Tests_PatientId",
                table: "Patient_Tests",
                newName: "IX_Patient_Tests_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient_Tests",
                table: "Patient_Tests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Tests_Patients_PatientId",
                table: "Patient_Tests",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Tests_Tests_TestId",
                table: "Patient_Tests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Tests_Patients_PatientId",
                table: "Patient_Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Tests_Tests_TestId",
                table: "Patient_Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient_Tests",
                table: "Patient_Tests");

            migrationBuilder.RenameTable(
                name: "Patient_Tests",
                newName: "patient_Tests");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_Tests_TestId",
                table: "patient_Tests",
                newName: "IX_patient_Tests_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_Tests_PatientId",
                table: "patient_Tests",
                newName: "IX_patient_Tests_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patient_Tests",
                table: "patient_Tests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_Tests_Patients_PatientId",
                table: "patient_Tests",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_Tests_Tests_TestId",
                table: "patient_Tests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

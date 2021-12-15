using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class s1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    YearOfBirth = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    IsTemplate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MedicineId = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    NoDay = table.Column<int>(nullable: false),
                    NoTimeToTakeMedicine = table.Column<int>(nullable: false),
                    Dosage = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    TreatmentId = table.Column<string>(nullable: true),
                    TreatmentId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentDetail_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentDetail_Treatment_TreatmentId1",
                        column: x => x.TreatmentId1,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PatiendId = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: true),
                    Cost = table.Column<long>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Symptoms = table.Column<string>(nullable: true),
                    TreatmentId = table.Column<Guid>(nullable: true),
                    TreatById = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_User_TreatById",
                        column: x => x.TreatById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TreatById",
                table: "Appointment",
                column: "TreatById");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TreatmentId",
                table: "Appointment",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentDetail_MedicineId",
                table: "TreatmentDetail",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentDetail_TreatmentId1",
                table: "TreatmentDetail",
                column: "TreatmentId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "TreatmentDetail");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Treatment");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL.Migrations
{
    /// <inheritdoc />
    public partial class PetsInits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListOfServices = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicOwner",
                columns: table => new
                {
                    ClinicSubscriptionsId = table.Column<int>(type: "int", nullable: false),
                    Patient = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicOwner", x => new { x.ClinicSubscriptionsId, x.Patient });
                    table.ForeignKey(
                        name: "FK_ClinicOwner_Clinic_ClinicSubscriptionsId",
                        column: x => x.ClinicSubscriptionsId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicOwner_Owners_Patient",
                        column: x => x.Patient,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicOwner_Owners_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OwnerSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerSettings_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecordOwner",
                columns: table => new
                {
                    MedicalOwnersId = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecordOwner", x => new { x.MedicalOwnersId, x.MedicalRecordsId });
                    table.ForeignKey(
                        name: "FK_MedicalRecordOwner_MedicalRecord_MedicalRecordsId",
                        column: x => x.MedicalRecordsId,
                        principalTable: "MedicalRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecordOwner_Owners_MedicalOwnersId",
                        column: x => x.MedicalOwnersId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicOwner_Patient",
                table: "ClinicOwner",
                column: "Patient");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicOwner_PatientsId",
                table: "ClinicOwner",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_ClinicId",
                table: "MedicalRecord",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordOwner_MedicalRecordsId",
                table: "MedicalRecordOwner",
                column: "MedicalRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerSettings_OwnerId",
                table: "OwnerSettings",
                column: "OwnerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicOwner");

            migrationBuilder.DropTable(
                name: "MedicalRecordOwner");

            migrationBuilder.DropTable(
                name: "OwnerSettings");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Clinic");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Hippocrates.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDrugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedicationScheduleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationTimes_MedicationSchedules_MedicationScheduleId",
                        column: x => x.MedicationScheduleId,
                        principalTable: "MedicationSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugDosages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DrugId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedicationTimeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<uint>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDosages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugDosages_MedicalDrugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "MedicalDrugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugDosages_MedicationTimes_MedicationTimeId",
                        column: x => x.MedicationTimeId,
                        principalTable: "MedicationTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugDosages_DrugId",
                table: "DrugDosages",
                column: "DrugId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrugDosages_MedicationTimeId",
                table: "DrugDosages",
                column: "MedicationTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationTimes_MedicationScheduleId",
                table: "MedicationTimes",
                column: "MedicationScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugDosages");

            migrationBuilder.DropTable(
                name: "MedicalDrugs");

            migrationBuilder.DropTable(
                name: "MedicationTimes");

            migrationBuilder.DropTable(
                name: "MedicationSchedules");
        }
    }
}

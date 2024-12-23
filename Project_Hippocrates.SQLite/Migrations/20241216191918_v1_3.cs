using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Hippocrates.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class v1_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugDosages_MedicalDrugs_DrugId",
                table: "DrugDosages");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugDosages_MedicalDrugs_DrugId",
                table: "DrugDosages",
                column: "DrugId",
                principalTable: "MedicalDrugs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugDosages_MedicalDrugs_DrugId",
                table: "DrugDosages");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugDosages_MedicalDrugs_DrugId",
                table: "DrugDosages",
                column: "DrugId",
                principalTable: "MedicalDrugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Hippocrates.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class v1_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PushNotificationId",
                table: "MedicationTimes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "MedicationSchedules",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f5fd4ea2-9bd4-456f-b704-af8f4c9b82e6"), "Главное расписание" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicationSchedules",
                keyColumn: "Id",
                keyValue: new Guid("f5fd4ea2-9bd4-456f-b704-af8f4c9b82e6"));

            migrationBuilder.DropColumn(
                name: "PushNotificationId",
                table: "MedicationTimes");
        }
    }
}

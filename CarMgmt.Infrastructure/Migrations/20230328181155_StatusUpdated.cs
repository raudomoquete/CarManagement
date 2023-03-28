using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMgmt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Vehicles_VehicleId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_VehicleId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Stats");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_StatusId",
                table: "Vehicles",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Stats_StatusId",
                table: "Vehicles",
                column: "StatusId",
                principalTable: "Stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Stats_StatusId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_StatusId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_VehicleId",
                table: "Stats",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Vehicles_VehicleId",
                table: "Stats",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

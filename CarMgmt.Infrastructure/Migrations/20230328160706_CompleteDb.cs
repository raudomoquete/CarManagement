using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMgmt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompleteDb : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Models",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Vehicles_VehicleId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_VehicleId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Models");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Stats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_VehicleId",
                table: "Stats",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Vehicles_VehicleId",
                table: "Stats",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}

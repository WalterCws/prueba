using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnicaInfraestructure.Migrations
{
    public partial class AddEstadoVuelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AerolineaId",
                table: "VUELOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "VUELOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VUELOS_AerolineaId",
                table: "VUELOS",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_VUELOS_EstadoId",
                table: "VUELOS",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VUELOS_AEROLINEAS_AerolineaId",
                table: "VUELOS",
                column: "AerolineaId",
                principalTable: "AEROLINEAS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VUELOS_ESTADOSVUELO_EstadoId",
                table: "VUELOS",
                column: "EstadoId",
                principalTable: "ESTADOSVUELO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VUELOS_AEROLINEAS_AerolineaId",
                table: "VUELOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VUELOS_ESTADOSVUELO_EstadoId",
                table: "VUELOS");

            migrationBuilder.DropIndex(
                name: "IX_VUELOS_AerolineaId",
                table: "VUELOS");

            migrationBuilder.DropIndex(
                name: "IX_VUELOS_EstadoId",
                table: "VUELOS");

            migrationBuilder.DropColumn(
                name: "AerolineaId",
                table: "VUELOS");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "VUELOS");
        }
    }
}

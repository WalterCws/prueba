using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnicaInfraestructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AEROLINEAS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AEROLINEAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTAMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTAMENTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOSVUELO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOSVUELO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CIUDADES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIUDADES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CIUDADES_DEPARTAMENTOS_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "DEPARTAMENTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VUELOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSalida = table.Column<DateTime>(nullable: false),
                    FechaLlegada = table.Column<DateTime>(nullable: false),
                    CiudadDestinoId = table.Column<int>(nullable: false),
                    CiudadOrigenId = table.Column<int>(nullable: false),
                    NumeroVuelo = table.Column<int>(nullable: false),
                    NuevoVueloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VUELOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VUELOS_CIUDADES_CiudadDestinoId",
                        column: x => x.CiudadDestinoId,
                        principalTable: "CIUDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VUELOS_CIUDADES_CiudadOrigenId",
                        column: x => x.CiudadOrigenId,
                        principalTable: "CIUDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VUELOS_VUELOS_NuevoVueloId",
                        column: x => x.NuevoVueloId,
                        principalTable: "VUELOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CIUDADES_DepartamentoId",
                table: "CIUDADES",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_VUELOS_CiudadDestinoId",
                table: "VUELOS",
                column: "CiudadDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_VUELOS_CiudadOrigenId",
                table: "VUELOS",
                column: "CiudadOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_VUELOS_NuevoVueloId",
                table: "VUELOS",
                column: "NuevoVueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AEROLINEAS");

            migrationBuilder.DropTable(
                name: "ESTADOSVUELO");

            migrationBuilder.DropTable(
                name: "VUELOS");

            migrationBuilder.DropTable(
                name: "CIUDADES");

            migrationBuilder.DropTable(
                name: "DEPARTAMENTOS");
        }
    }
}

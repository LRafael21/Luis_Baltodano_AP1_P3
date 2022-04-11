using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luis_Baltodano_AP1_P3.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NumeroCedula = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentarios = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Plan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    MontoFacturado = table.Column<float>(type: "REAL", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "ContratosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<float>(type: "REAL", nullable: false),
                    Importe = table.Column<float>(type: "REAL", nullable: false),
                    MontoTotal = table.Column<float>(type: "REAL", nullable: false),
                    serviciosServicioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosDetalle_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosDetalle_Servicios_serviciosServicioId",
                        column: x => x.serviciosServicioId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosDetalle_ContratoId",
                table: "ContratosDetalle",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosDetalle_serviciosServicioId",
                table: "ContratosDetalle",
                column: "serviciosServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ContratosDetalle");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}

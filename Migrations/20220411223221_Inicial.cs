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
                    NumeroCedula = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
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
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    MontoFacturado = table.Column<float>(type: "REAL", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                    table.ForeignKey(
                        name: "FK_Servicios_Planes_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<float>(type: "REAL", nullable: false),
                    Importe = table.Column<float>(type: "REAL", nullable: false),
                    MontoTotal = table.Column<float>(type: "REAL", nullable: false),
                    serviciosServicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "Internet(5Mbps - 1Mbps) - Cable(120 Canales)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 2, "Internet (100Mbps - 50Mbps) - Cable (300 Canales)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 3, "Internet (5Mbps - 1Mbps)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 4, "(10Mbps - 5Mbps)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 5, "Internet (100Mbps - 50Mbps)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 6, "Cable (120 Canales)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 7, " Cable (150 Canales)" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 8, "Cable (300 Canales)" });

            migrationBuilder.CreateIndex(
                name: "IX_ContratosDetalle_ContratoId",
                table: "ContratosDetalle",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosDetalle_serviciosServicioId",
                table: "ContratosDetalle",
                column: "serviciosServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_PlanId",
                table: "Servicios",
                column: "PlanId");
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

            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}

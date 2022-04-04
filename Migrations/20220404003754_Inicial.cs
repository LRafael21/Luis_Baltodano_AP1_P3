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
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Plan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}

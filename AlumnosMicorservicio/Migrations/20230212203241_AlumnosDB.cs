using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumnosMicorservicio.Migrations
{
    public partial class AlumnosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlumnoInscrito",
                columns: table => new
                {
                    AlumnoInscritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAlumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlumnoInscritoGuid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoInscrito", x => x.AlumnoInscritoId);
                });

            migrationBuilder.CreateTable(
                name: "CarreraAlumno",
                columns: table => new
                {
                    CarreraAlumnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlCarrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlumnoInscritoId = table.Column<int>(type: "int", nullable: true),
                    CarreraAlumnoGuid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraAlumno", x => x.CarreraAlumnoId);
                    table.ForeignKey(
                        name: "FK_CarreraAlumno_AlumnoInscrito_AlumnoInscritoId",
                        column: x => x.AlumnoInscritoId,
                        principalTable: "AlumnoInscrito",
                        principalColumn: "AlumnoInscritoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarreraAlumno_AlumnoInscritoId",
                table: "CarreraAlumno",
                column: "AlumnoInscritoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarreraAlumno");

            migrationBuilder.DropTable(
                name: "AlumnoInscrito");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamientos",
                columns: table => new
                {
                    pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    ciudad = table.Column<string>(type: "varchar(50)", nullable: true),
                    barrio = table.Column<string>(type: "varchar(50)", nullable: true),
                    estrellas = table.Column<int>(type: "int", nullable: false),
                    cantPersonas = table.Column<int>(type: "int", nullable: false),
                    tv = table.Column<bool>(type: "bit", nullable: false),
                    precioDia = table.Column<int>(type: "int", nullable: false),
                    habitaciones = table.Column<int>(type: "int", nullable: false),
                    baños = table.Column<int>(type: "int", nullable: false),
                    precioPorPersona = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamientos", x => x.pk);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    num_usr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Mail = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.num_usr);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    pk = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    fdesde = table.Column<DateTime>(type: "datetime", nullable: false),
                    fhasta = table.Column<DateTime>(type: "datetime", nullable: false),
                    propiedadpk = table.Column<int>(nullable: true),
                    personanum_usr = table.Column<int>(nullable: true),
                    propiedadint = table.Column<int>(type: "int", nullable: false),
                    personaint = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.pk);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuarios_personanum_usr",
                        column: x => x.personanum_usr,
                        principalTable: "Usuarios",
                        principalColumn: "num_usr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Alojamientos_propiedadpk",
                        column: x => x.propiedadpk,
                        principalTable: "Alojamientos",
                        principalColumn: "pk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_personanum_usr",
                table: "Reserva",
                column: "personanum_usr");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_propiedadpk",
                table: "Reserva",
                column: "propiedadpk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Alojamientos");
        }
    }
}

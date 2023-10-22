using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaTuristica.API.Migrations
{
    /// <inheritdoc />
    public partial class migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recorridos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recorridos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SitiosTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitiosTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitiosTuristicos_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SitiosTuristicos_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagoInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagoFinal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecorridoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Recorridos_RecorridoId",
                        column: x => x.RecorridoId,
                        principalTable: "Recorridos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SitiosRecorridos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SitioTuristicoId = table.Column<int>(type: "int", nullable: false),
                    RecorridoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitiosRecorridos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitiosRecorridos_Recorridos_RecorridoId",
                        column: x => x.RecorridoId,
                        principalTable: "Recorridos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SitiosRecorridos_SitiosTuristicos_SitioTuristicoId",
                        column: x => x.SitioTuristicoId,
                        principalTable: "SitiosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_Nombre",
                table: "Actividades",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Nombre",
                table: "Ciudades",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recorridos_Nombre",
                table: "Recorridos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_RecorridoId",
                table: "Reservas",
                column: "RecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosRecorridos_RecorridoId",
                table: "SitiosRecorridos",
                column: "RecorridoId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosRecorridos_SitioTuristicoId",
                table: "SitiosRecorridos",
                column: "SitioTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosTuristicos_ActividadId",
                table: "SitiosTuristicos",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosTuristicos_CiudadId",
                table: "SitiosTuristicos",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_SitiosTuristicos_Nombre",
                table: "SitiosTuristicos",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "SitiosRecorridos");

            migrationBuilder.DropTable(
                name: "Recorridos");

            migrationBuilder.DropTable(
                name: "SitiosTuristicos");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}

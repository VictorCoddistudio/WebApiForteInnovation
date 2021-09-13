using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIForteT.Migrations
{
    public partial class addMigrationPermisos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPermisos",
                columns: table => new
                {
                    TipoPermisoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPermisos", x => x.TipoPermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPermisoId = table.Column<int>(type: "int", nullable: false),
                    FechaPermiso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisos_TipoPermisos_TipoPermisoId",
                        column: x => x.TipoPermisoId,
                        principalTable: "TipoPermisos",
                        principalColumn: "TipoPermisoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoPermisos",
                columns: new[] { "TipoPermisoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Enfermedad" },
                    { 2, "Diligencias" },
                    { 3, "Matrimonio" },
                    { 4, "Mudanza" }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "ApellidosEmpleado", "FechaPermiso", "NombreEmpleado", "TipoPermisoId" },
                values: new object[,]
                {
                    { 1, "Sosa Juarez", new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto", 1 },
                    { 2, "Pinales Lopez", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nataly", 1 },
                    { 4, "Rodriguez Gracia", new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karla", 3 },
                    { 3, "Sandoval Jaramillo", new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mateo", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_TipoPermisoId",
                table: "Permisos",
                column: "TipoPermisoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "TipoPermisos");
        }
    }
}

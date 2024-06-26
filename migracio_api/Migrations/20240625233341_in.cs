using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migracio_api.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NInss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cierradeContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deducciones",
                columns: table => new
                {
                    EmpleadoId = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InssLaboral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtrasDeduccion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inatec = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InssPatronal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpleadoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deducciones", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_deducciones_empleados_EmpleadoId1",
                        column: x => x.EmpleadoId1,
                        principalTable: "empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "ingresos",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bono = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtrosIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiesgoNocturnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpleadoId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresos", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_ingresos_empleados_EmpleadoId1",
                        column: x => x.EmpleadoId1,
                        principalTable: "empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nominas",
                columns: table => new
                {
                    EmpleadoId = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraExtra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bono = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtrosIngresos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiesgoNocturnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemuneracionBruta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InssLaboral = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtrasDeduccion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemuneracionNeta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inatec = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InssPatronal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemuneracionEmpresaarial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpleadoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nominas", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_nominas_empleados_EmpleadoId1",
                        column: x => x.EmpleadoId1,
                        principalTable: "empleados",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_deducciones_EmpleadoId1",
                table: "deducciones",
                column: "EmpleadoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_EmpleadoId1",
                table: "ingresos",
                column: "EmpleadoId1");

            migrationBuilder.CreateIndex(
                name: "IX_nominas_EmpleadoId1",
                table: "nominas",
                column: "EmpleadoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deducciones");

            migrationBuilder.DropTable(
                name: "ingresos");

            migrationBuilder.DropTable(
                name: "nominas");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "empleados");
        }
    }
}

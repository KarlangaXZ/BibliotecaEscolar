using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaEscolar.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIBLIOTECARIOS",
                columns: table => new
                {
                    ID_BIBLIOTECARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CodigoEmpleado = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIBLIOTECARIOS", x => x.ID_BIBLIOTECARIO);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Matricula = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "LIBROS",
                columns: table => new
                {
                    ID_LIBRO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Autor = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    AnioPublicacion = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Disponible = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ID_CATEGORIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIBROS", x => x.ID_LIBRO);
                    table.ForeignKey(
                        name: "FK_LIBROS_CATEGORIAS_ID_CATEGORIA",
                        column: x => x.ID_CATEGORIA,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRESTAMOS",
                columns: table => new
                {
                    ID_PRESTAMO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_BIBLIOTECARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_LIBRO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Devuelto = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESTAMOS", x => x.ID_PRESTAMO);
                    table.ForeignKey(
                        name: "FK_PRESTAMOS_BIBLIOTECARIOS_ID_BIBLIOTECARIO",
                        column: x => x.ID_BIBLIOTECARIO,
                        principalTable: "BIBLIOTECARIOS",
                        principalColumn: "ID_BIBLIOTECARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRESTAMOS_LIBROS_ID_LIBRO",
                        column: x => x.ID_LIBRO,
                        principalTable: "LIBROS",
                        principalColumn: "ID_LIBRO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRESTAMOS_USUARIOS_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UX_BIBLIOTECARIOS_CODIGO",
                table: "BIBLIOTECARIOS",
                column: "CodigoEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LIBROS_ID_CATEGORIA",
                table: "LIBROS",
                column: "ID_CATEGORIA");

            migrationBuilder.CreateIndex(
                name: "UX_LIBROS_ISBN",
                table: "LIBROS",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRESTAMOS_ID_BIBLIOTECARIO",
                table: "PRESTAMOS",
                column: "ID_BIBLIOTECARIO");

            migrationBuilder.CreateIndex(
                name: "IX_PRESTAMOS_ID_LIBRO",
                table: "PRESTAMOS",
                column: "ID_LIBRO");

            migrationBuilder.CreateIndex(
                name: "IX_PRESTAMOS_ID_USUARIO",
                table: "PRESTAMOS",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "UX_USUARIOS_MATRICULA",
                table: "USUARIOS",
                column: "Matricula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRESTAMOS");

            migrationBuilder.DropTable(
                name: "BIBLIOTECARIOS");

            migrationBuilder.DropTable(
                name: "LIBROS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");
        }
    }
}

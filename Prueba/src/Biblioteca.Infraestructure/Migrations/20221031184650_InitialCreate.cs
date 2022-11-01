using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infraestructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreAutor = table.Column<string>(type: "TEXT", nullable: false),
                    EdadAutor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreEditorial = table.Column<string>(type: "TEXT", nullable: false),
                    MatrizEditorial = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreLibro = table.Column<string>(type: "TEXT", nullable: false),
                    PrecioLibro = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEditorial = table.Column<int>(type: "INTEGER", nullable: false),
                    EditorialLibroIdEditorial = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAutor = table.Column<int>(type: "INTEGER", nullable: false),
                    AutorLibroIdAutor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_AutorLibroIdAutor",
                        column: x => x.AutorLibroIdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_EditorialLibroIdEditorial",
                        column: x => x.EditorialLibroIdEditorial,
                        principalTable: "Editoriales",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorLibroIdAutor",
                table: "Libros",
                column: "AutorLibroIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialLibroIdEditorial",
                table: "Libros",
                column: "EditorialLibroIdEditorial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}

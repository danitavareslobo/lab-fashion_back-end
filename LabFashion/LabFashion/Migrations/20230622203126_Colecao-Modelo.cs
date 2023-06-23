using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class ColecaoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeColecao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdResponsavel = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Orcamento = table.Column<double>(type: "float", maxLength: 21, nullable: false),
                    AnoLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estacao = table.Column<int>(type: "int", nullable: false),
                    EstadoSistema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colecoes_Usuarios_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdColecaoRelacionada = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Colecoes_IdColecaoRelacionada",
                        column: x => x.IdColecaoRelacionada,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_IdResponsavel",
                table: "Colecoes",
                column: "IdResponsavel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdColecaoRelacionada",
                table: "Modelos",
                column: "IdColecaoRelacionada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Colecoes");
        }
    }
}

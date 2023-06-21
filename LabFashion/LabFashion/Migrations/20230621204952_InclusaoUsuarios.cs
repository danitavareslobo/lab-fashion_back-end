using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeCommpleto",
                table: "Usuarios",
                newName: "NomeCompleto");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CpfCnpj", "DataNascimento", "Email", "Genero", "NomeCompleto", "Status", "Telefone", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "000.000.000.-00", new DateTime(1990, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "diego@audaces.com", "M", "Diego Lobo", 2, "9999-9999", 1 },
                    { 2, "111.111.111.11", new DateTime(1989, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniele@audaces.com", "F", "Daniele Lobo", 1, "8888-8888", 1 },
                    { 3, "222.222.222-22", new DateTime(1995, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcella@audaces.com", "F", "Marcella Lobo", 2, "7777-7777", 3 },
                    { 4, "333.333.333-33", new DateTime(1994, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabelle@audaces.com", "F", "Isabelle Tavares", 1, "6666-6666", 3 },
                    { 5, "444.444.444-44", new DateTime(1993, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "gustavo@audaces.com", "M", "Gustavo Tavares", 2, "5555-5555", 2 },
                    { 6, "555.555.555-55", new DateTime(1992, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "enrico@audaces.com", "M", "Enrico Tavares", 1, "4444-4444", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Usuarios",
                newName: "NomeCommpleto");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gastos.API.Migrations
{
    /// <inheritdoc />
    public partial class ajusteBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorObejtivo",
                table: "MetasFinanceiras",
                newName: "ValorObjetivo");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Categorias",
                newName: "Descriçao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFechamento",
                table: "Transaçoes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFechamento",
                table: "Transaçoes");

            migrationBuilder.RenameColumn(
                name: "ValorObjetivo",
                table: "MetasFinanceiras",
                newName: "ValorObejtivo");

            migrationBuilder.RenameColumn(
                name: "Descriçao",
                table: "Categorias",
                newName: "Tipo");
        }
    }
}

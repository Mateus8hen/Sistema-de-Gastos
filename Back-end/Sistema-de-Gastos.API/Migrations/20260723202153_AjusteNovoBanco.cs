using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gastos.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNovoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataFechamento",
                table: "Transaçoes",
                newName: "Fechamento");

            migrationBuilder.RenameColumn(
                name: "Descriçao",
                table: "Categorias",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Categorias",
                newName: "Criacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fechamento",
                table: "Transaçoes",
                newName: "DataFechamento");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Categorias",
                newName: "Descriçao");

            migrationBuilder.RenameColumn(
                name: "Criacao",
                table: "Categorias",
                newName: "DataCriacao");
        }
    }
}

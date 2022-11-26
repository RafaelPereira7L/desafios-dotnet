using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniERP.Migrations
{
    public partial class Versao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Produtos_IdProduto",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_IdFornecedor",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Notas_IdProduto",
                table: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorIdFornecedor",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorIdFornecedor",
                table: "Produtos",
                column: "FornecedorIdFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorIdFornecedor",
                table: "Produtos",
                column: "FornecedorIdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "IdFornecedor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorIdFornecedor",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorIdFornecedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "FornecedorIdFornecedor",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdProduto",
                table: "Notas",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Produtos_IdProduto",
                table: "Notas",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "IdFornecedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

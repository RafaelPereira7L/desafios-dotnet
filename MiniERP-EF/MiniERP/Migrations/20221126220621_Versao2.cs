using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniERP.Migrations
{
    public partial class Versao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalIdProduto",
                table: "Notas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_TotalIdProduto",
                table: "Notas",
                column: "TotalIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Produtos_TotalIdProduto",
                table: "Notas",
                column: "TotalIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Produtos_TotalIdProduto",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_TotalIdProduto",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "TotalIdProduto",
                table: "Notas");
        }
    }
}

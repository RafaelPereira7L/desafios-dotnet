using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniERP.Migrations
{
    public partial class Versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Notas",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "TotalIdProduto",
                table: "Notas",
                type: "int",
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
    }
}

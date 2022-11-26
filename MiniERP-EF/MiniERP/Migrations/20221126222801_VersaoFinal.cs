using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniERP.Migrations
{
    public partial class VersaoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Clientes_IdCliente",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_IdCliente",
                table: "Notas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdCliente",
                table: "Notas",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clientes_IdCliente",
                table: "Notas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

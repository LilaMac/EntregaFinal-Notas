using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprenderMVC.Migrations
{
    public partial class addInscritoResultado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Curso_IdCurso",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Pessoa_IdPessoa",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Turma_IdPessoa",
                table: "Turma");

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Inscrito",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Inscrito");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdPessoa",
                table: "Turma",
                column: "IdPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Curso_IdCurso",
                table: "Turma",
                column: "IdCurso",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Pessoa_IdPessoa",
                table: "Turma",
                column: "IdPessoa",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoConteudo.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGestaoConteudoEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Cursos_CursoId",
                table: "Aulas");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Cursos_CursoId",
                table: "Aulas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Cursos_CursoId",
                table: "Aulas");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Cursos_CursoId",
                table: "Aulas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoAlunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatriculaValorStatusMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Matriculas",
                newName: "MatriculaStatus");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Matriculas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Matriculas");

            migrationBuilder.RenameColumn(
                name: "MatriculaStatus",
                table: "Matriculas",
                newName: "Status");
        }
    }
}

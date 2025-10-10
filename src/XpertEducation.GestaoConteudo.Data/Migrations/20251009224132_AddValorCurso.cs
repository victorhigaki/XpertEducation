using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoConteudo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddValorCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Cursos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Cursos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoConteudo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConteudoProgramatico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConteudoProgramatico",
                table: "Cursos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "Bibliografia",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conteudo",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Metodologia",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objetivo",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Aulas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "ConteudoAula",
                table: "Aulas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bibliografia",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Conteudo",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Metodologia",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Objetivo",
                table: "Cursos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cursos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConteudoProgramatico",
                table: "Cursos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Aulas",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConteudoAula",
                table: "Aulas",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }
    }
}

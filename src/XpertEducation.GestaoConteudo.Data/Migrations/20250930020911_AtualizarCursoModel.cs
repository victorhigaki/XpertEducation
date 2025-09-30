using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoConteudo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarCursoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Aulas_AulaId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_AulaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "AulaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Conteudo",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "ConteudoProgramatico_Bibliografia",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Metodologia",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Objetivo",
                table: "Cursos");

            migrationBuilder.AddColumn<string>(
                name: "ConteudoProgramatico",
                table: "Cursos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Aulas",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<Guid>(
                name: "CursoId",
                table: "Aulas",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CursoId",
                table: "Aulas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Cursos_CursoId",
                table: "Aulas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Cursos_CursoId",
                table: "Aulas");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_CursoId",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "ConteudoProgramatico",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Aulas");

            migrationBuilder.AddColumn<Guid>(
                name: "AulaId",
                table: "Cursos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Conteudo",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConteudoProgramatico_Bibliografia",
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
                name: "Material",
                table: "Aulas",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AulaId",
                table: "Cursos",
                column: "AulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Aulas_AulaId",
                table: "Cursos",
                column: "AulaId",
                principalTable: "Aulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

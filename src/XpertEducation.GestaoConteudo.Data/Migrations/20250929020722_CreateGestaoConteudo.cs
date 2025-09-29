using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoConteudo.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateGestaoConteudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    ConteudoAula = table.Column<string>(type: "varchar(100)", nullable: false),
                    Material = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    AulaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Objetivo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Conteudo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Metodologia = table.Column<string>(type: "varchar(100)", nullable: true),
                    ConteudoProgramatico_Bibliografia = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AulaId",
                table: "Cursos",
                column: "AulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Aulas");
        }
    }
}

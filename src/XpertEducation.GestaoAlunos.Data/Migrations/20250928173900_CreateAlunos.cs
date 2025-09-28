using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoAlunos.Data.Migrations;

/// <inheritdoc />
public partial class CreateAlunos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Alunos",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Alunos", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Matricula",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                AlunoId = table.Column<Guid>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Matricula", x => x.Id);
                table.ForeignKey(
                    name: "FK_Matricula_Alunos_AlunoId",
                    column: x => x.AlunoId,
                    principalTable: "Alunos",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Matricula_AlunoId",
            table: "Matricula",
            column: "AlunoId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Matricula");

        migrationBuilder.DropTable(
            name: "Alunos");
    }
}

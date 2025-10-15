using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.GestaoAlunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHistoricoAprendizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoAprendizado_Alunos_AlunoId",
                table: "HistoricoAprendizado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoricoAprendizado",
                table: "HistoricoAprendizado");

            migrationBuilder.RenameTable(
                name: "HistoricoAprendizado",
                newName: "HistoricosAprendizados");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoAprendizado_AlunoId",
                table: "HistoricosAprendizados",
                newName: "IX_HistoricosAprendizados_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoricosAprendizados",
                table: "HistoricosAprendizados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricosAprendizados_Alunos_AlunoId",
                table: "HistoricosAprendizados",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricosAprendizados_Alunos_AlunoId",
                table: "HistoricosAprendizados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoricosAprendizados",
                table: "HistoricosAprendizados");

            migrationBuilder.RenameTable(
                name: "HistoricosAprendizados",
                newName: "HistoricoAprendizado");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricosAprendizados_AlunoId",
                table: "HistoricoAprendizado",
                newName: "IX_HistoricoAprendizado_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoricoAprendizado",
                table: "HistoricoAprendizado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoAprendizado_Alunos_AlunoId",
                table: "HistoricoAprendizado",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }
    }
}

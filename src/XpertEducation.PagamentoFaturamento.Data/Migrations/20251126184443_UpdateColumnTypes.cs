using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XpertEducation.PagamentoFaturamento.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Pagamentos",
                type: "varchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pagamentos",
                type: "varchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Expiracao",
                table: "Pagamentos",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<Guid>(
                name: "DadosCartao_Id",
                table: "Pagamentos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Pagamentos",
                type: "VARCHAR(4)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Pagamentos",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pagamentos",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Expiracao",
                table: "Pagamentos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DadosCartao_Id",
                table: "Pagamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Pagamentos",
                type: "VARCHAR(4)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(4)",
                oldNullable: true);
        }
    }
}

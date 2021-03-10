using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Itau.Teste.Infra.Data.Migrations
{
    public partial class SeedAjustesFinanceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                columns: new[] { "ID", "CONCILIADO", "DATA_HORA_LANCAMENTO", "TIPO", "VALOR" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2021, 3, 1, 12, 4, 0, 0, DateTimeKind.Unspecified), 2, 3000m },
                    { 2, false, new DateTime(2021, 3, 1, 13, 3, 0, 0, DateTimeKind.Unspecified), 1, 100m },
                    { 3, false, new DateTime(2021, 3, 1, 14, 2, 0, 0, DateTimeKind.Unspecified), 1, 55m },
                    { 4, false, new DateTime(2021, 3, 2, 14, 3, 0, 0, DateTimeKind.Unspecified), 2, 72m },
                    { 5, false, new DateTime(2021, 3, 2, 14, 47, 0, 0, DateTimeKind.Unspecified), 1, 153m },
                    { 6, true, new DateTime(2021, 3, 3, 15, 43, 0, 0, DateTimeKind.Unspecified), 1, 342m },
                    { 7, false, new DateTime(2021, 3, 3, 15, 32, 0, 0, DateTimeKind.Unspecified), 1, 75m },
                    { 8, false, new DateTime(2021, 3, 3, 16, 57, 0, 0, DateTimeKind.Unspecified), 1, 145m },
                    { 9, false, new DateTime(2021, 3, 3, 17, 34, 0, 0, DateTimeKind.Unspecified), 2, 234m },
                    { 10, false, new DateTime(2021, 3, 4, 17, 41, 0, 0, DateTimeKind.Unspecified), 2, 876m },
                    { 11, false, new DateTime(2021, 4, 4, 18, 35, 0, 0, DateTimeKind.Unspecified), 2, 234m },
                    { 12, false, new DateTime(2021, 4, 4, 11, 24, 0, 0, DateTimeKind.Unspecified), 2, 56m },
                    { 13, false, new DateTime(2021, 4, 4, 11, 21, 0, 0, DateTimeKind.Unspecified), 2, 213m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "teste_itau.LANCAMENTOS_FINANCEIROS",
                keyColumn: "ID",
                keyValue: 13);
        }
    }
}

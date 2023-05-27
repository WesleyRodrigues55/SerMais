using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class DataConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA_HORA",
                table: "CONSULTA",
                newName: "DATA_START");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_END",
                table: "CONSULTA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATA_END",
                table: "CONSULTA");

            migrationBuilder.RenameColumn(
                name: "DATA_START",
                table: "CONSULTA",
                newName: "DATA_HORA");
        }
    }
}

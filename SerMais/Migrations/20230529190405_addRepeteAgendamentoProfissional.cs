using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class addRepeteAgendamentoProfissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "REPETE_SEGUNDA_DOMINGO",
                table: "AGENDA_PROFISSIONAL",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "REPETE_SEGUNDA_SABADO",
                table: "AGENDA_PROFISSIONAL",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "REPETE_SEGUNDA_SEXTA",
                table: "AGENDA_PROFISSIONAL",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REPETE_SEGUNDA_DOMINGO",
                table: "AGENDA_PROFISSIONAL");

            migrationBuilder.DropColumn(
                name: "REPETE_SEGUNDA_SABADO",
                table: "AGENDA_PROFISSIONAL");

            migrationBuilder.DropColumn(
                name: "REPETE_SEGUNDA_SEXTA",
                table: "AGENDA_PROFISSIONAL");
        }
    }
}

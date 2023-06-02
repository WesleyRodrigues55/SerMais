using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class addRepeteAgendamentoProfissional2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REPETE_SEGUNDA_DOMINGO",
                table: "AGENDA_PROFISSIONAL");

            migrationBuilder.DropColumn(
                name: "REPETE_SEGUNDA_SABADO",
                table: "AGENDA_PROFISSIONAL");

            migrationBuilder.RenameColumn(
                name: "REPETE_SEGUNDA_SEXTA",
                table: "AGENDA_PROFISSIONAL",
                newName: "REPETE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "REPETE",
                table: "AGENDA_PROFISSIONAL",
                newName: "REPETE_SEGUNDA_SEXTA");

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
        }
    }
}

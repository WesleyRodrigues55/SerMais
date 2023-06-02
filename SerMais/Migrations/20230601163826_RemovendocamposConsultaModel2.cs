using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class RemovendocamposConsultaModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FORMA_DE_PAGAMENTO",
                table: "CONSULTAS");

            migrationBuilder.RenameColumn(
                name: "LINK_REUNIAO",
                table: "CONSULTAS",
                newName: "TIPO_REUNIAO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TIPO_REUNIAO",
                table: "CONSULTAS",
                newName: "LINK_REUNIAO");

            migrationBuilder.AddColumn<string>(
                name: "FORMA_DE_PAGAMENTO",
                table: "CONSULTAS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigracaoAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROFISSIONAL_TIPO_PROFISSIONAL_ID_TIPO_PROFISSIONALID",
                table: "PROFISSIONAL");

            migrationBuilder.DropTable(
                name: "TIPO_PROFISSIONAL");

            migrationBuilder.DropIndex(
                name: "IX_PROFISSIONAL_ID_TIPO_PROFISSIONALID",
                table: "PROFISSIONAL");

            migrationBuilder.DropColumn(
                name: "ID_TIPO_PROFISSIONALID",
                table: "PROFISSIONAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_TIPO_PROFISSIONALID",
                table: "PROFISSIONAL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TIPO_PROFISSIONAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATIVO = table.Column<int>(type: "int", nullable: false),
                    NOME_TIPO_PROFISSIONAL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_PROFISSIONAL", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_ID_TIPO_PROFISSIONALID",
                table: "PROFISSIONAL",
                column: "ID_TIPO_PROFISSIONALID");

            migrationBuilder.AddForeignKey(
                name: "FK_PROFISSIONAL_TIPO_PROFISSIONAL_ID_TIPO_PROFISSIONALID",
                table: "PROFISSIONAL",
                column: "ID_TIPO_PROFISSIONALID",
                principalTable: "TIPO_PROFISSIONAL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

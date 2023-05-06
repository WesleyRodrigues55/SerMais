using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class addFileModelPortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMAGEM_PROFILE",
                table: "PORTFOLIO",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMAGEM_PROFILE",
                table: "PORTFOLIO");
        }
    }
}

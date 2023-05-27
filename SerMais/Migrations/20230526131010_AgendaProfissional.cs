using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class AgendaProfissional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGENDA_PROFISSIONAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HORA_START = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HORA_END = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DIA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_PROFISSIONALID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA_PROFISSIONAL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AGENDA_PROFISSIONAL_PROFISSIONAL_ID_PROFISSIONALID",
                        column: x => x.ID_PROFISSIONALID,
                        principalTable: "PROFISSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_PROFISSIONAL_ID_PROFISSIONALID",
                table: "AGENDA_PROFISSIONAL",
                column: "ID_PROFISSIONALID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDA_PROFISSIONAL");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class DROPAGENDAMENTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CONSULTAS_AGENDAMENTOS_ID_AGENDAMENTOID",
                table: "CONSULTAS");

            migrationBuilder.DropTable(
                name: "AGENDAMENTOS");

            migrationBuilder.RenameColumn(
                name: "ID_AGENDAMENTOID",
                table: "CONSULTAS",
                newName: "ID_CLIENTEID");

            migrationBuilder.RenameIndex(
                name: "IX_CONSULTAS_ID_AGENDAMENTOID",
                table: "CONSULTAS",
                newName: "IX_CONSULTAS_ID_CLIENTEID");

            migrationBuilder.AddColumn<int>(
                name: "ID_AGENDA_PROFISSIONALID",
                table: "CONSULTAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTAS_ID_AGENDA_PROFISSIONALID",
                table: "CONSULTAS",
                column: "ID_AGENDA_PROFISSIONALID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONSULTAS_AGENDA_PROFISSIONAL_ID_AGENDA_PROFISSIONALID",
                table: "CONSULTAS",
                column: "ID_AGENDA_PROFISSIONALID",
                principalTable: "AGENDA_PROFISSIONAL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CONSULTAS_CLIENTE_ID_CLIENTEID",
                table: "CONSULTAS",
                column: "ID_CLIENTEID",
                principalTable: "CLIENTE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CONSULTAS_AGENDA_PROFISSIONAL_ID_AGENDA_PROFISSIONALID",
                table: "CONSULTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_CONSULTAS_CLIENTE_ID_CLIENTEID",
                table: "CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_CONSULTAS_ID_AGENDA_PROFISSIONALID",
                table: "CONSULTAS");

            migrationBuilder.DropColumn(
                name: "ID_AGENDA_PROFISSIONALID",
                table: "CONSULTAS");

            migrationBuilder.RenameColumn(
                name: "ID_CLIENTEID",
                table: "CONSULTAS",
                newName: "ID_AGENDAMENTOID");

            migrationBuilder.RenameIndex(
                name: "IX_CONSULTAS_ID_CLIENTEID",
                table: "CONSULTAS",
                newName: "IX_CONSULTAS_ID_AGENDAMENTOID");

            migrationBuilder.CreateTable(
                name: "AGENDAMENTOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_AGENDA_PROFISSIONALID = table.Column<int>(type: "int", nullable: false),
                    ID_CLIENTEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAMENTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTOS_AGENDA_PROFISSIONAL_ID_AGENDA_PROFISSIONALID",
                        column: x => x.ID_AGENDA_PROFISSIONALID,
                        principalTable: "AGENDA_PROFISSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTOS_CLIENTE_ID_CLIENTEID",
                        column: x => x.ID_CLIENTEID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTOS_ID_AGENDA_PROFISSIONALID",
                table: "AGENDAMENTOS",
                column: "ID_AGENDA_PROFISSIONALID");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTOS_ID_CLIENTEID",
                table: "AGENDAMENTOS",
                column: "ID_CLIENTEID");

            migrationBuilder.AddForeignKey(
                name: "FK_CONSULTAS_AGENDAMENTOS_ID_AGENDAMENTOID",
                table: "CONSULTAS",
                column: "ID_AGENDAMENTOID",
                principalTable: "AGENDAMENTOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

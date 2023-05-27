using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class novamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTO_CLIENTE_ID_CLIENTEID",
                table: "AGENDAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTO_PROFISSIONAL_ID_PROFISSIONALID",
                table: "AGENDAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_CONSULTA_AGENDAMENTO_ID_AGENDAMENTOID",
                table: "CONSULTA");

            migrationBuilder.DropForeignKey(
                name: "FK_CONSULTA_TIPO_CONSULTA_MODEL_ID_TIPO_CONSULTAID",
                table: "CONSULTA");

            migrationBuilder.DropTable(
                name: "TIPO_CONSULTA_MODEL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CONSULTA",
                table: "CONSULTA");

            migrationBuilder.DropIndex(
                name: "IX_CONSULTA_ID_TIPO_CONSULTAID",
                table: "CONSULTA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AGENDAMENTO",
                table: "AGENDAMENTO");

            migrationBuilder.DropColumn(
                name: "ID_TIPO_CONSULTAID",
                table: "CONSULTA");

            migrationBuilder.RenameTable(
                name: "CONSULTA",
                newName: "CONSULTAS");

            migrationBuilder.RenameTable(
                name: "AGENDAMENTO",
                newName: "AGENDAMENTOS");

            migrationBuilder.RenameIndex(
                name: "IX_CONSULTA_ID_AGENDAMENTOID",
                table: "CONSULTAS",
                newName: "IX_CONSULTAS_ID_AGENDAMENTOID");

            migrationBuilder.RenameIndex(
                name: "IX_AGENDAMENTO_ID_PROFISSIONALID",
                table: "AGENDAMENTOS",
                newName: "IX_AGENDAMENTOS_ID_PROFISSIONALID");

            migrationBuilder.RenameIndex(
                name: "IX_AGENDAMENTO_ID_CLIENTEID",
                table: "AGENDAMENTOS",
                newName: "IX_AGENDAMENTOS_ID_CLIENTEID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONSULTAS",
                table: "CONSULTAS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AGENDAMENTOS",
                table: "AGENDAMENTOS",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTOS_CLIENTE_ID_CLIENTEID",
                table: "AGENDAMENTOS",
                column: "ID_CLIENTEID",
                principalTable: "CLIENTE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAL_ID_PROFISSIONALID",
                table: "AGENDAMENTOS",
                column: "ID_PROFISSIONALID",
                principalTable: "PROFISSIONAL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CONSULTAS_AGENDAMENTOS_ID_AGENDAMENTOID",
                table: "CONSULTAS",
                column: "ID_AGENDAMENTOID",
                principalTable: "AGENDAMENTOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTOS_CLIENTE_ID_CLIENTEID",
                table: "AGENDAMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTOS_PROFISSIONAL_ID_PROFISSIONALID",
                table: "AGENDAMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_CONSULTAS_AGENDAMENTOS_ID_AGENDAMENTOID",
                table: "CONSULTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CONSULTAS",
                table: "CONSULTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AGENDAMENTOS",
                table: "AGENDAMENTOS");

            migrationBuilder.RenameTable(
                name: "CONSULTAS",
                newName: "CONSULTA");

            migrationBuilder.RenameTable(
                name: "AGENDAMENTOS",
                newName: "AGENDAMENTO");

            migrationBuilder.RenameIndex(
                name: "IX_CONSULTAS_ID_AGENDAMENTOID",
                table: "CONSULTA",
                newName: "IX_CONSULTA_ID_AGENDAMENTOID");

            migrationBuilder.RenameIndex(
                name: "IX_AGENDAMENTOS_ID_PROFISSIONALID",
                table: "AGENDAMENTO",
                newName: "IX_AGENDAMENTO_ID_PROFISSIONALID");

            migrationBuilder.RenameIndex(
                name: "IX_AGENDAMENTOS_ID_CLIENTEID",
                table: "AGENDAMENTO",
                newName: "IX_AGENDAMENTO_ID_CLIENTEID");

            migrationBuilder.AddColumn<int>(
                name: "ID_TIPO_CONSULTAID",
                table: "CONSULTA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONSULTA",
                table: "CONSULTA",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AGENDAMENTO",
                table: "AGENDAMENTO",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "TIPO_CONSULTA_MODEL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_TIPO_CONSULTA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_CONSULTA_MODEL", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_ID_TIPO_CONSULTAID",
                table: "CONSULTA",
                column: "ID_TIPO_CONSULTAID");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTO_CLIENTE_ID_CLIENTEID",
                table: "AGENDAMENTO",
                column: "ID_CLIENTEID",
                principalTable: "CLIENTE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTO_PROFISSIONAL_ID_PROFISSIONALID",
                table: "AGENDAMENTO",
                column: "ID_PROFISSIONALID",
                principalTable: "PROFISSIONAL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CONSULTA_AGENDAMENTO_ID_AGENDAMENTOID",
                table: "CONSULTA",
                column: "ID_AGENDAMENTOID",
                principalTable: "AGENDAMENTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CONSULTA_TIPO_CONSULTA_MODEL_ID_TIPO_CONSULTAID",
                table: "CONSULTA",
                column: "ID_TIPO_CONSULTAID",
                principalTable: "TIPO_CONSULTA_MODEL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

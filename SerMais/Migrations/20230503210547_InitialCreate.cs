using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROFISSIONAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SOBRENOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RUA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BAIRRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CIDADE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false),
                    NIVEL = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONAL", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "AGENDAMENTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PROFISSIONALID = table.Column<int>(type: "int", nullable: false),
                    ID_CLIENTEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAMENTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_CLIENTE_ID_CLIENTEID",
                        column: x => x.ID_CLIENTEID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_PROFISSIONAL_ID_PROFISSIONALID",
                        column: x => x.ID_PROFISSIONALID,
                        principalTable: "PROFISSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PORTFOLIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESPECIALIDADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VALOR_CONSULTA = table.Column<double>(type: "float", nullable: true),
                    FORMAS_PAGAMENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DURACAO_SESSAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATENDE_CONSULTA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TELEFONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CELULAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FORMACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SOBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_PROFISSIONALID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PORTFOLIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PORTFOLIO_PROFISSIONAL_ID_PROFISSIONALID",
                        column: x => x.ID_PROFISSIONALID,
                        principalTable: "PROFISSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    POLITICA = table.Column<int>(type: "int", nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false),
                    ID_PROFISSIONALID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_PROFISSIONAL_ID_PROFISSIONALID",
                        column: x => x.ID_PROFISSIONALID,
                        principalTable: "PROFISSIONAL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONSULTA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUEIXA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LINK_REUNIAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FORMA_DE_PAGAMENTO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID_TIPO_CONSULTAID = table.Column<int>(type: "int", nullable: false),
                    ID_AGENDAMENTOID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONSULTA_AGENDAMENTO_ID_AGENDAMENTOID",
                        column: x => x.ID_AGENDAMENTOID,
                        principalTable: "AGENDAMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONSULTA_TIPO_CONSULTA_MODEL_ID_TIPO_CONSULTAID",
                        column: x => x.ID_TIPO_CONSULTAID,
                        principalTable: "TIPO_CONSULTA_MODEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_ID_CLIENTEID",
                table: "AGENDAMENTO",
                column: "ID_CLIENTEID");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_ID_PROFISSIONALID",
                table: "AGENDAMENTO",
                column: "ID_PROFISSIONALID");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_ID_AGENDAMENTOID",
                table: "CONSULTA",
                column: "ID_AGENDAMENTOID");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_ID_TIPO_CONSULTAID",
                table: "CONSULTA",
                column: "ID_TIPO_CONSULTAID");

            migrationBuilder.CreateIndex(
                name: "IX_PORTFOLIO_ID_PROFISSIONALID",
                table: "PORTFOLIO",
                column: "ID_PROFISSIONALID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ID_PROFISSIONALID",
                table: "USUARIO",
                column: "ID_PROFISSIONALID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSULTA");

            migrationBuilder.DropTable(
                name: "PORTFOLIO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "AGENDAMENTO");

            migrationBuilder.DropTable(
                name: "TIPO_CONSULTA_MODEL");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "PROFISSIONAL");
        }
    }
}

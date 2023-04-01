using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerMais.Migrations
{
    /// <inheritdoc />
    public partial class TablePessoaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRP = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CELULAR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RUA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BAIRRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CIDADE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USUARIO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false),
                    NIVEL = table.Column<int>(type: "int", nullable: false),
                    PessoaModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_PESSOA_PessoaModelID",
                        column: x => x.PessoaModelID,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PessoaModelID",
                table: "USUARIO",
                column: "PessoaModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "PESSOA");
        }
    }
}

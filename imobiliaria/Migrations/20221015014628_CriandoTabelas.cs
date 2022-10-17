using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobiliaria.Migrations
{
    public partial class CriandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inquilinos",
                columns: table => new
                {
                    IdInquilino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilinos", x => x.IdInquilino);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    IdProprietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.IdProprietario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    IdImovel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QtQuartos = table.Column<int>(type: "int", nullable: false),
                    QtBanheiros = table.Column<int>(type: "int", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    IdProprietario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.IdImovel);
                    table.ForeignKey(
                        name: "FK_Imoveis_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imoveis_Proprietarios_IdProprietario",
                        column: x => x.IdProprietario,
                        principalTable: "Proprietarios",
                        principalColumn: "IdProprietario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    idContratoAluguel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataAssinatura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IdInquilino = table.Column<int>(type: "int", nullable: false),
                    IdImovel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.idContratoAluguel);
                    table.ForeignKey(
                        name: "FK_Contratos_Imoveis_IdImovel",
                        column: x => x.IdImovel,
                        principalTable: "Imoveis",
                        principalColumn: "IdImovel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Inquilinos_IdInquilino",
                        column: x => x.IdInquilino,
                        principalTable: "Inquilinos",
                        principalColumn: "IdInquilino",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdImovel",
                table: "Contratos",
                column: "IdImovel");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdInquilino",
                table: "Contratos",
                column: "IdInquilino");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_IdEndereco",
                table: "Imoveis",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_IdProprietario",
                table: "Imoveis",
                column: "IdProprietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Inquilinos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Proprietarios");
        }
    }
}

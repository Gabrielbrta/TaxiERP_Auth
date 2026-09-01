using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxiERP.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    SenhaCriada = table.Column<bool>(type: "bit", nullable: false),
                    CriadoPorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Organizacoes_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_CriadoPorId",
                        column: x => x.CriadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPermissoes",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPermissoes", x => new { x.UsuarioId, x.PermissaoId });
                    table.ForeignKey(
                        name: "FK_UsuarioPermissoes_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPermissoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissao",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Pode visualizar a lista de motoristas", "Motorista:Visualizar" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Pode cadastrar novos motoristas", "Motorista:Criar" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Pode editar dados de motoristas", "Motorista:Editar" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Pode deletar motoristas", "Motorista:Deletar" },
                    { new Guid("20000000-0000-0000-0000-000000000001"), "Pode visualizar a lista de associados", "Associado:Visualizar" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "Pode cadastrar novos associados", "Associado:Criar" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "Pode editar dados de associados", "Associado:Editar" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "Pode deletar associados", "Associado:Deletar" },
                    { new Guid("30000000-0000-0000-0000-000000000001"), "Pode visualizar a lista de banidos", "Banido:Visualizar" },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "Pode banir usuários/motoristas", "Banido:Criar" },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "Pode editar status de banidos", "Banido:Editar" },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "Pode remover da lista de banidos", "Banido:Deletar" },
                    { new Guid("40000000-0000-0000-0000-000000000001"), "Pode visualizar ocorrências", "Ocorrencia:Visualizar" },
                    { new Guid("40000000-0000-0000-0000-000000000002"), "Pode registrar novas ocorrências", "Ocorrencia:Criar" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "Pode editar ocorrências", "Ocorrencia:Editar" },
                    { new Guid("40000000-0000-0000-0000-000000000004"), "Pode deletar ocorrências", "Ocorrencia:Deletar" },
                    { new Guid("50000000-0000-0000-0000-000000000001"), "Pode visualizar unidades", "Unidade:Visualizar" },
                    { new Guid("50000000-0000-0000-0000-000000000002"), "Pode cadastrar novas unidades", "Unidade:Criar" },
                    { new Guid("50000000-0000-0000-0000-000000000003"), "Pode editar unidades", "Unidade:Editar" },
                    { new Guid("50000000-0000-0000-0000-000000000004"), "Pode deletar unidades", "Unidade:Deletar" },
                    { new Guid("60000000-0000-0000-0000-000000000001"), "Pode visualizar a lista de usuários", "Usuario:Visualizar" },
                    { new Guid("60000000-0000-0000-0000-000000000002"), "Pode criar novos usuários", "Usuario:Criar" },
                    { new Guid("60000000-0000-0000-0000-000000000003"), "Pode editar usuários", "Usuario:Editar" },
                    { new Guid("60000000-0000-0000-0000-000000000004"), "Pode deletar usuários", "Usuario:Deletar" },
                    { new Guid("70000000-0000-0000-0000-000000000001"), "Pode criar seu próprio perfil (registro inicial)", "Perfil:Criar" },
                    { new Guid("70000000-0000-0000-0000-000000000002"), "Pode editar seu próprio perfil", "Perfil:Editar" },
                    { new Guid("80000000-0000-0000-0000-000000000001"), "Pode visualizar o dashboard principal", "Dashboard:Visualizar" },
                    { new Guid("90000000-0000-0000-0000-000000000001"), "Pode enviar a solicitação de alteração de senha", "Acao:AlterarSenha" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermissoes_PermissaoId",
                table: "UsuarioPermissoes",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CriadoPorId",
                table: "Usuarios",
                column: "CriadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_OrganizacaoId",
                table: "Usuarios",
                column: "OrganizacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioPermissoes");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Organizacoes");
        }
    }
}

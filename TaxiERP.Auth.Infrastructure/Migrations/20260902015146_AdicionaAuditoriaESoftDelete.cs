using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiERP.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaAuditoriaESoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioPermissoes_Permissao_PermissaoId",
                table: "UsuarioPermissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioPermissoes_Usuarios_UsuarioId",
                table: "UsuarioPermissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Organizacoes_OrganizacaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Organizacoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpCadastro",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavegadorCadastro",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Permissao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Permissao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Permissao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Organizacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Organizacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Organizacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Permissao",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPermissoes_Permissao_PermissaoId",
                table: "UsuarioPermissoes",
                column: "PermissaoId",
                principalTable: "Permissao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPermissoes_Usuarios_UsuarioId",
                table: "UsuarioPermissoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Organizacoes_OrganizacaoId",
                table: "Usuarios",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioPermissoes_Permissao_PermissaoId",
                table: "UsuarioPermissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioPermissoes_Usuarios_UsuarioId",
                table: "UsuarioPermissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Organizacoes_OrganizacaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IpCadastro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NavegadorCadastro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Permissao");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Organizacoes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Organizacoes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Organizacoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Organizacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPermissoes_Permissao_PermissaoId",
                table: "UsuarioPermissoes",
                column: "PermissaoId",
                principalTable: "Permissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPermissoes_Usuarios_UsuarioId",
                table: "UsuarioPermissoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Organizacoes_OrganizacaoId",
                table: "Usuarios",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Domain.Entities;

namespace TaxiERP.Auth.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPermissao>()
                .HasKey(up => new { up.UsuarioId, up.PermissaoId });

            modelBuilder.Entity<UsuarioPermissao>()
                .HasOne(up => up.Usuario)
                .WithMany(u => u.UsuarioPermissoes)
                .HasForeignKey(up => up.UsuarioId)
                .IsRequired(false);

            modelBuilder.Entity<UsuarioPermissao>()
                .HasOne(up => up.Permissao)
                .WithMany(p => p.UsuarioPermissoes)
                .HasForeignKey(p => p.PermissaoId)
                .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Organizacao)
                .WithMany(o => o.Usuarios)
                .HasForeignKey(u => u.OrganizacaoId)
                .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.CriadoPor)
                .WithMany()
                .HasForeignKey(u => u.CriadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Permissao>().HasData(
                // Motoristas
                new Permissao(Guid.Parse("10000000-0000-0000-0000-000000000001"), "Motorista:Visualizar", "Pode visualizar a lista de motoristas"),
                new Permissao(Guid.Parse("10000000-0000-0000-0000-000000000002"), "Motorista:Criar", "Pode cadastrar novos motoristas"),
                new Permissao(Guid.Parse("10000000-0000-0000-0000-000000000003"), "Motorista:Editar", "Pode editar dados de motoristas"),
                new Permissao(Guid.Parse("10000000-0000-0000-0000-000000000004"), "Motorista:Deletar", "Pode deletar motoristas"),

                // Associados
                new Permissao(Guid.Parse("20000000-0000-0000-0000-000000000001"), "Associado:Visualizar", "Pode visualizar a lista de associados"),
                new Permissao(Guid.Parse("20000000-0000-0000-0000-000000000002"), "Associado:Criar", "Pode cadastrar novos associados"),
                new Permissao(Guid.Parse("20000000-0000-0000-0000-000000000003"), "Associado:Editar", "Pode editar dados de associados"),
                new Permissao(Guid.Parse("20000000-0000-0000-0000-000000000004"), "Associado:Deletar", "Pode deletar associados"),

                // Banidos
                new Permissao(Guid.Parse("30000000-0000-0000-0000-000000000001"), "Banido:Visualizar", "Pode visualizar a lista de banidos"),
                new Permissao(Guid.Parse("30000000-0000-0000-0000-000000000002"), "Banido:Criar", "Pode banir usuários/motoristas"),
                new Permissao(Guid.Parse("30000000-0000-0000-0000-000000000003"), "Banido:Editar", "Pode editar status de banidos"),
                new Permissao(Guid.Parse("30000000-0000-0000-0000-000000000004"), "Banido:Deletar", "Pode remover da lista de banidos"),

                // Ocorrências
                new Permissao(Guid.Parse("40000000-0000-0000-0000-000000000001"), "Ocorrencia:Visualizar", "Pode visualizar ocorrências"),
                new Permissao(Guid.Parse("40000000-0000-0000-0000-000000000002"), "Ocorrencia:Criar", "Pode registrar novas ocorrências"),
                new Permissao(Guid.Parse("40000000-0000-0000-0000-000000000003"), "Ocorrencia:Editar", "Pode editar ocorrências"),
                new Permissao(Guid.Parse("40000000-0000-0000-0000-000000000004"), "Ocorrencia:Deletar", "Pode deletar ocorrências"),

                // Unidades
                new Permissao(Guid.Parse("50000000-0000-0000-0000-000000000001"), "Unidade:Visualizar", "Pode visualizar unidades"),
                new Permissao(Guid.Parse("50000000-0000-0000-0000-000000000002"), "Unidade:Criar", "Pode cadastrar novas unidades"),
                new Permissao(Guid.Parse("50000000-0000-0000-0000-000000000003"), "Unidade:Editar", "Pode editar unidades"),
                new Permissao(Guid.Parse("50000000-0000-0000-0000-000000000004"), "Unidade:Deletar", "Pode deletar unidades"),

                // Usuários
                new Permissao(Guid.Parse("60000000-0000-0000-0000-000000000001"), "Usuario:Visualizar", "Pode visualizar a lista de usuários"),
                new Permissao(Guid.Parse("60000000-0000-0000-0000-000000000002"), "Usuario:Criar", "Pode criar novos usuários"),
                new Permissao(Guid.Parse("60000000-0000-0000-0000-000000000003"), "Usuario:Editar", "Pode editar usuários"),
                new Permissao(Guid.Parse("60000000-0000-0000-0000-000000000004"), "Usuario:Deletar", "Pode deletar usuários"),

                // Perfil
                new Permissao(Guid.Parse("70000000-0000-0000-0000-000000000001"), "Perfil:Criar", "Pode criar seu próprio perfil (registro inicial)"),
                new Permissao(Guid.Parse("70000000-0000-0000-0000-000000000002"), "Perfil:Editar", "Pode editar seu próprio perfil"),

                // Dashboard
                new Permissao(Guid.Parse("80000000-0000-0000-0000-000000000001"), "Dashboard:Visualizar", "Pode visualizar o dashboard principal"),

                // Admin
                new Permissao(Guid.Parse("90000000-0000-0000-0000-000000000001"), "Acao:AlterarSenha", "Pode enviar a solicitação de alteração de senha")
            );



            modelBuilder.Entity<Usuario>().HasQueryFilter(u => u.DeletedAt == null);
            modelBuilder.Entity<Organizacao>().HasQueryFilter(o => o.DeletedAt == null);
            modelBuilder.Entity<Permissao>().HasQueryFilter(o => o.DeletedAt == null);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries) { 
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                } 
                else if(entry.State == EntityState.Modified)
                {
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

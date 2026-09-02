using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Domain.Enums;

namespace TaxiERP.Auth.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Guid OrganizacaoId { get; private set; }
        public TipoUsuario Tipo { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Nome { get; private set; }
        public string? IpCadastro { get; private set; }
        public string? NavegadorCadastro { get; private set; }
        public string SenhaHash { get; private set; }
        public bool Ativo { get; private set; }
        public bool SenhaCriada { get; private set; }
        public Guid? CriadoPorId { get; private set; }

        public Organizacao Organizacao { get; private set; }
        public Usuario? CriadoPor { get; private set; }
        public ICollection<UsuarioPermissao> UsuarioPermissoes { get; private set; } = new List<UsuarioPermissao>();

        protected Usuario() { }

        public Usuario(string nome, string email, string telefone, Guid organizacaoId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Telefone = telefone;
            OrganizacaoId = organizacaoId;
            Tipo = TipoUsuario.Admin;
            Ativo = true;
            SenhaCriada = false;
            CreatedAt = DateTime.UtcNow;
        }
        public Usuario(string nome, string email, string telefone, Guid organizacaoId, TipoUsuario tipo, Guid criadoPorId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Telefone = telefone;
            OrganizacaoId = organizacaoId;
            Tipo = tipo;
            CriadoPorId = criadoPorId;
            Ativo = true;
            SenhaCriada = false;
            CreatedAt = DateTime.UtcNow;
        }
         
        public void DefinirSenha(string senhaHash)
        {
            SenhaHash = senhaHash;
            SenhaCriada = true;
        }

        public void DefinirMetadadosCadastro(string ip, string navegador)
        {
            IpCadastro = ip;
            NavegadorCadastro = navegador;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;   
        }
    }
}

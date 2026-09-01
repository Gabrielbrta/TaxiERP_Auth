using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiERP.Auth.Domain.Entities
{
    public class Permissao
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public ICollection<UsuarioPermissao> UsuarioPermissoes { get; private set; } = new List<UsuarioPermissao>();

        protected Permissao() { }

        public Permissao(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
        public Permissao(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
        }
    }
}

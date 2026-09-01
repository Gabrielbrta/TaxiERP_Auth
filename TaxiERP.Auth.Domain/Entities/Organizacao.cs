using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiERP.Auth.Domain.Entities
{
    public class Organizacao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CnpjCpf { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCriacao { get; private set; }

        public ICollection<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        protected Organizacao() {}

        public Organizacao(string nome, string cnpjCpf, string tipo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CnpjCpf = cnpjCpf;
            Tipo = tipo;
            DataCriacao = DateTime.UtcNow;
        }
    }
}

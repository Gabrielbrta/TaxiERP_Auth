using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Domain.Entities;

namespace TaxiERP.Auth.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> BuscarPorEmail(string email);
        Task<Usuario?> BuscarPorId(Guid id);
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Desativar(Guid id);

    }
}

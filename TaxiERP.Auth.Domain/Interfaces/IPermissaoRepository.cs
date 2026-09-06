using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Domain.Entities;

namespace TaxiERP.Auth.Domain.Interfaces
{
    public interface IPermissaoRepository
    {
        Task<IEnumerable<Permissao>> BuscarTodasAsync();
    }
}

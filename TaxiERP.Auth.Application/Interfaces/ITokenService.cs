using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Domain.Entities;

namespace TaxiERP.Auth.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}

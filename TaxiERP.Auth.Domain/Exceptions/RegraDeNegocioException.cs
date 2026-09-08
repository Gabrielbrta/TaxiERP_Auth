using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiERP.Auth.Domain.Exceptions
{
    public class RegraDeNegocioException : Exception
    {

        public RegraDeNegocioException(string mensagem) : base(mensagem) { }
    }
}

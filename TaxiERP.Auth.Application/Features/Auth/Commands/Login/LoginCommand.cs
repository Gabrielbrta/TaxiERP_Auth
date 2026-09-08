using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Application.Features.Auth.Commands.Login;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

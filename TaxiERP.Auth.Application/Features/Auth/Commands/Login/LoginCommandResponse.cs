using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.Login
{
    public class LoginCommandResponse
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Token { get; set; }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao;

namespace TaxiERP.Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarOrganizacaoCommand command)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Desconhecido";
            var navegador = Request.Headers["User-Agent"].ToString();

            command.Ip = ip;
            command.Navegador = navegador;

            var resultado = await _mediator.Send(command);

            return CreatedAtAction(nameof (Registrar), new {id = resultado.OrganizacaoId}, resultado);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TaxiERP.Auth.Application.Features.Auth.Commands.Login;
using TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao;

namespace TaxiERP.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;

        public AuthController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost("login")]
        [EnableRateLimiting("LoginLimit")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var resultado = await _mediator.Send(command);
            var cookieOptions = new CookieOptions
            {
                Secure = !_env.IsDevelopment(),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Path = "/",
                Expires = DateTime.UtcNow.AddHours(8)
            };
            Response.Cookies.Append("USER_TOKEN", resultado.Token, cookieOptions);
            return Ok(resultado);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var cookieOptions = new CookieOptions
            {
                Secure = !_env.IsDevelopment(),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Path = "/", 
                Expires = DateTime.UtcNow.AddDays(-1)
            };
            Response.Cookies.Delete("USER_TOKEN", cookieOptions);
            return Ok(new { mensagem = "Logout realizado com sucesso!" });
        }
    }
}

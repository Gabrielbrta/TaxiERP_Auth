using BCrypt.Net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Application.Features.Auth.Commands.LoginOrganizacao;
using TaxiERP.Auth.Application.Interfaces;
using TaxiERP.Auth.Domain.Entities;
using TaxiERP.Auth.Domain.Exceptions;
using TaxiERP.Auth.Domain.Interfaces;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        public LoginCommandHandler(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _usuarioRepository.BuscarPorEmail(request.Email);

            if (usuario == null) {
                throw new RegraDeNegocioException("E-mail ou senha inválidos!");
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash);
            if (!senhaValida) { 
                throw new RegraDeNegocioException("E-mail ou senha inválidos!");
            }

            return new LoginCommandResponse {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Token = _tokenService.GerarToken(usuario)
            };
        }
    }
}

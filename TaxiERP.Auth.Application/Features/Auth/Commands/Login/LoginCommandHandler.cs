using BCrypt.Net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Application.Features.Auth.Commands.LoginOrganizacao;
using TaxiERP.Auth.Domain.Entities;
using TaxiERP.Auth.Domain.Exceptions;
using TaxiERP.Auth.Domain.Interfaces;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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
                UsuarioId =  usuario.Id,  
                Nome = usuario.Nome, 
                Email = usuario.Email
            };
        }
    }
}

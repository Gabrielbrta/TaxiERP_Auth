using BCrypt.Net;
using MediatR;
using TaxiERP.Auth.Domain.Entities;
using TaxiERP.Auth.Domain.Interfaces;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao
{
    public class RegistrarOrganizacaoCommandHandler: IRequestHandler<RegistrarOrganizacaoCommand, RegistrarOrganizacaoResponse>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public RegistrarOrganizacaoCommandHandler(IOrganizacaoRepository organizacaoRepository, IUsuarioRepository usuarioRepository)
        {
            _organizacaoRepository = organizacaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RegistrarOrganizacaoResponse> Handle(RegistrarOrganizacaoCommand request, CancellationToken cancellationToken)
        {
            var organizacao = new Organizacao(request.NomeOrganizacao, request.CnpjCpf, request.Tipo);
            await _organizacaoRepository.Adicionar(organizacao);

            var usuario = new Usuario(request.NomeAdmin, request.Email, request.Telefone, organizacao.Id);
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha, workFactor: 12);
            usuario.DefinirSenha(senhaHash);

            usuario.DefinirMetadadosCadastro(
                request.Ip ?? "Desconhecido",
                request.Navegador ?? "Desconhecido"
            );

            await _usuarioRepository.Adicionar(usuario);

            return new RegistrarOrganizacaoResponse
            {
                OrganizacaoId = organizacao.Id,
                UsuarioId = usuario.Id
            };
                
        }

    }
}

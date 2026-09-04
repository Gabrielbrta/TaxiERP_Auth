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
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarOrganizacaoCommandHandler(
            IOrganizacaoRepository organizacaoRepository, 
            IUsuarioRepository usuarioRepository,
            IUnitOfWork unitOfWork
            )
        {
            _organizacaoRepository = organizacaoRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegistrarOrganizacaoResponse> Handle(RegistrarOrganizacaoCommand request, CancellationToken cancellationToken)
        {
            var organizacao = new Organizacao(request.NomeOrganizacao, request.CnpjCpf, request.Tipo);

            if (organizacao == null) { 
                throw new Exception("Ocorreu um erro ao adicionar organização");
            }

            await _organizacaoRepository.Adicionar(organizacao);

            var usuario = new Usuario(request.NomeAdmin, request.Email, request.Telefone, organizacao.Id);

            if (usuario is null)
            {
                throw new Exception("Ocorreu um erro ao criar usuário");
            }

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha, workFactor: 12);
            usuario.DefinirSenha(senhaHash);

            usuario.DefinirMetadadosCadastro(
                request.Ip ?? "Desconhecido",
                request.Navegador ?? "Desconhecido"
            );

            await _usuarioRepository.Adicionar(usuario);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new RegistrarOrganizacaoResponse
            {
                OrganizacaoId = organizacao.Id,
                UsuarioId = usuario.Id
            };
        }

    }
}

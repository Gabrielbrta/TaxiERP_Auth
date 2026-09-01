using MediatR;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao
{
    public class RegistrarOrganizacaoCommand : IRequest<RegistrarOrganizacaoResponse>
    {
        public string NomeOrganizacao { get; set; } = String.Empty;
        public string CnpjCpf { get; set; } = String.Empty;
        public string Tipo { get; set; } = String.Empty;
        public string NomeAdmin { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Telefone { get; set; } = String.Empty;
        public string Senha { get; set; } = String.Empty;
        public string? Ip { get; set; }
        public string? Navegador { get; set; }
    }
}

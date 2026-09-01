using FluentValidation;
using System.Runtime.ConstrainedExecution;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao
{
    public class RegistrarOrganizacaoCommandValidator: AbstractValidator<RegistrarOrganizacaoCommand>
    {
        public RegistrarOrganizacaoCommandValidator()
        {
            RuleFor(x => x.NomeOrganizacao)
                .NotEmpty().WithMessage("O nome da organização é obrigatório")
                .MinimumLength(5).WithMessage("O nome deve ter pelo menos 5 caracteres");

            RuleFor(x => x.CnpjCpf)
                .NotEmpty().WithMessage("O CNPJ/CPF é obrigatório")
                .MinimumLength(11).WithMessage("O CNPJ/CPF deve ter no mínimo 11 caracteres.")
                .MaximumLength(14).WithMessage("O CNPJ/CPF deve ter no máximo 14 caracteres.");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("O tipo (Pessoa jurídica ou Pessoa física) é obrigatório.")
                .Must(tipo => tipo == "PJ" || tipo == "PF")
                .WithMessage("O tipo deve ser 'PJ' ou 'PF'");

            RuleFor(x => x.NomeAdmin)
                .NotEmpty().WithMessage("O nome do administrador é obrigatório")
                .MinimumLength(5).WithMessage("O nome deve ter pelo menos 5 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .MaximumLength(60).WithMessage("O e-mail pode ter no máximo 60 caracteres")
                .EmailAddress().WithMessage("O formato do e-mail é inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MinimumLength(10).WithMessage("O telefone deve ter pelo menos 10 caracteres.")
                .MaximumLength(13).WithMessage("O telefone pode ter no máximo 14 caracteres");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial (ex: @, #, $, !).");
        }
    }
}

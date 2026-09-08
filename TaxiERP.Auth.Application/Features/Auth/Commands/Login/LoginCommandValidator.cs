using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Application.Features.Auth.Commands.Login;

namespace TaxiERP.Auth.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {

        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("O campo de e-mail não pode estar vazio!")
                .EmailAddress().WithMessage("Digite um e-mail válido!");

            RuleFor(l => l.Senha).NotEmpty().WithMessage("O campo de senha não pode estar vazio!");
        }
    }
}

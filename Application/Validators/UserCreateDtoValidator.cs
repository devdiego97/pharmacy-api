using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.User;
using FluentValidation;


namespace Application.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
		{
			RuleFor(x=>x.name).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).WithMessage("nome deve ter entre 5 e 50 caracteres");
			RuleFor(x=>x.lastName).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).WithMessage("sobrenome deve ter entre 5 e 50 caracteres");
			RuleFor(x=>x.email).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).EmailAddress().MinimumLength(5).MaximumLength(50).WithMessage("Email deve ser válido");
			RuleFor(x=>x.passHash).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(15).MaximumLength(50).WithMessage("a senha hash deve ter entre 15 e 50 caracteres ");
			RuleFor(x=>x.role).IsInEnum();

		}
    }
}
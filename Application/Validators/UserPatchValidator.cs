using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.User;
using FluentValidation;

namespace Application.Validators
{
    public class UserPatchValidator : AbstractValidator<UserPatchDto>
    {

		public UserPatchValidator(){
		     RuleFor(x=>x.name).Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).When(x => x.name != null).WithMessage("nome deve ter entre 5 e 50 caracteres");
			RuleFor(x=>x.lastName)  .Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).When(x => x.name != null).WithMessage("sobrenome deve ter entre 5 e 50 caracteres");
			RuleFor(x=>x.email)  .Must(x => !string.IsNullOrWhiteSpace(x)).EmailAddress().MinimumLength(5).MaximumLength(50).When(x => x.name != null).WithMessage("Email deve ser válido");
			RuleFor(x=>x.passHash)  .Must(x => !string.IsNullOrWhiteSpace(x)).MaximumLength(50).When(x => x.name != null).WithMessage("a senha hash deve ter entre 15 e 50 caracteres ");
			
		}
        
    }
}
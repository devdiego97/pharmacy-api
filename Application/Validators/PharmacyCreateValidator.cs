using System.Linq;
using Application.DTOS.PharmacyDto;
using FluentValidation;

namespace Application.Validators
{
    public class PharmacyCreateDtoValidator : AbstractValidator<PharmacyCreateDto>
    {
        public PharmacyCreateDtoValidator()
		{
		 
				
			RuleFor(x => x.Name).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).WithMessage("nome deve ter entre 5 e 50 caracteres");
			RuleFor(x => x.City).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).WithMessage("cidade deve ter entre 5 e 50 caracteres");
			RuleFor(x => x.State).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(2).MaximumLength(2).WithMessage("state deve ter entre no máximo 2 caracteres");
			RuleFor(x => x.Cnpj)
            .NotEmpty()
            .Must(BeValidCnpj)
            .WithMessage("CNPJ inválido.");

			RuleFor(x => x.Address).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(5).MaximumLength(50).WithMessage("endereço deve ter entre 5 e 50 caracteres");
			RuleFor(x => x.Email).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).EmailAddress().MinimumLength(5).MaximumLength(50).WithMessage("Email deve ser válido");
			RuleFor(x => x.PassHash).NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x)).MinimumLength(15).MaximumLength(50).WithMessage("a senha hash deve ter entre 15 e 50 caracteres ");
		}

		private static bool BeValidCnpj(string cnpj)
		{
			cnpj = new string(cnpj.Where(char.IsDigit).ToArray());
			return cnpj.Length == 14;
		}
    }
}
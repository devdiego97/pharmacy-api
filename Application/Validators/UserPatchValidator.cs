using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.UserDto;
using FluentValidation;

namespace Application.Validators
{
    public class UserPatchValidator : AbstractValidator<UserPatchDto>
    {

		public UserPatchValidator(){

			RuleFor(x => x.name)
					.NotEmpty()
					.MinimumLength(5)
					.MaximumLength(50)
					.When(x => x.name != null);

				RuleFor(x => x.lastName)
					.NotEmpty()
					.MinimumLength(5)
					.MaximumLength(50)
					.When(x => x.lastName != null);

				RuleFor(x => x.email)
					.NotEmpty()
					.EmailAddress()
					.MinimumLength(5)
					.MaximumLength(50)
					.When(x => x.email != null);

				RuleFor(x => x.passHash)
					.NotEmpty()
					.MinimumLength(15)
					.MaximumLength(50)
					.When(x => x.passHash != null);




			  }}

			

}
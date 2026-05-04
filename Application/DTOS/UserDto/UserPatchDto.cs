using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOS.UserDto
{
    public record  UserPatchDto
	(
		 string? name,
		string? lastName,
		string? email,
		string? passHash
	);
}
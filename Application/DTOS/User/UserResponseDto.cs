using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacy_api.Enum;

namespace Application.DTOS.User
{
    public record UserResponseDto
	(
		Guid id,
	    string name,
		string lastName,
		string email,
		string passHash,
		UserRole role
	);
}
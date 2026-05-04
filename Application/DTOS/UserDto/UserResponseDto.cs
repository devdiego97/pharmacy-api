

using Application.DTOS.PharmacyDto;
using pharmacy_api.Enum;

namespace Application.DTOS.UserDto
{
    public record UserResponseDto
	(
		Guid Id,
	    string Name,
		string LastName,
		string Email,
		string PassHash,
		UserRole Role,
		ICollection<PharmacyResponseDto>? Pharmacies
		
	);
}
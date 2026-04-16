
using Application.DTOS.Pharmacy;
using pharmacy_api.Enum;

namespace Application.DTOS.User
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
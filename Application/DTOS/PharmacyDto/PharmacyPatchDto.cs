namespace Application.DTOS.PharmacyDto
{
    public record PharmacyPatchDto
    (
		string? Name,
		string? Cnpj,
		string? City,
		string? State,
		string? Address,
		string? LogoUrl,		
		string? Phone,
		string? Email,
		string? PassHash,
		bool? Status
   );
}
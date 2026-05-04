using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.Category;

namespace Application.DTOS.PharmacyDto
{
    public record  PharmacyPacthDto
    (
    string? name,
	string? cnpj,
	string? city,
	string? state,
	string? address,
	string? logoUrl,		
	string? phone,
	string? email,
	string? passHash,
	bool? status
   );
}
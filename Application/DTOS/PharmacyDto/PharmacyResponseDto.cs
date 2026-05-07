using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.Category;
using Domain.Entities;


namespace Application.DTOS.PharmacyDto
{
    public record  PharmacyResponseDto
  (
	Guid Id,
    Guid IdAdmin,
    string Name,
	string Cnpj,
	string City,
	string State,
	string Address,
	string? LogoUrl,		
	string Phone,
	string Email,
	string PassHash,
	bool Status,
	ICollection<CategoryResponseDto>? Categories 
  );
}
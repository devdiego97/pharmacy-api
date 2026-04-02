using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.DTOS.Pharmacy
{
    public record  PharmacyResponseDto
  (
    Guid idAdmin,

         string name,
	   string cnpj,
	   string city,
		string state,
	  string address,
	   string? logoUrl,		
	    string phone,
		string email,
		 string passHash,
		bool status,
		ICollection<Category> Categories 
  );
}
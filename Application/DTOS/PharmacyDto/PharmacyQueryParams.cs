using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.shared;

namespace Application.DTOS.PharmacyDto
{
    public record  PharmacyQueryParams :GenericQueryParams
  
    {
        	public string? Email{get;init;}
			public string?  Cnpj{get;init;}
    }
}
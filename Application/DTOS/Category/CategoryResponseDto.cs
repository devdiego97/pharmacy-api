using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOS.Category
{
    public record  CategoryResponseDto(
		Guid id,
	    string name,
	    string description
	);
}
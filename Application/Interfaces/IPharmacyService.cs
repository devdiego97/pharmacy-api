using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.Common;
using Application.DTOS.PharmacyDto;

namespace Application.Interfaces
{
    public interface IPharmacyService
    {
          Task<PagedResult<PharmacyResponseDto>> GetPharmacyAsync(PharmacyQueryParams queryParams);
		  Task<PharmacyResponseDto> GetPharmacyId(Guid id);
		  Task<PharmacyResponseDto> AddAsync(PharmacyCreateDto dto);
		  Task DeletePharmacyAsync(Guid id);
		  Task PacthPharmacAsync(Guid id,PharmacyPacthDto dto);
    }
}
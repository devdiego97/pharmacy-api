using Application.DTOS.Common;
using Application.DTOS.PharmacyDto;

namespace Application.Interfaces
{
    public interface IPharmacyService
    {
          Task<PagedResult<PharmacyResponseDto>> GetPharmaciesAsync(PharmacyQueryParams queryParams);
		  Task<PharmacyResponseDto> GetPharmacyId(Guid id);
		  Task<PharmacyResponseDto> AddPharmacyAsync(PharmacyCreateDto dto);
		  Task DeletePharmacyAsync(Guid id);
		  Task PatchPharmacyAsync(Guid id, PharmacyPatchDto dto);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.Common;
using Application.DTOS.PharmacyDto;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class PharmacyService : IPharmacyService
	{
		private readonly IPharmacyRepository _pharmaRepo;
		private readonly IMapper _mapper;

		public PharmacyService( IPharmacyRepository pharmaRepo,IMapper mapper)
		{
			_pharmaRepo = pharmaRepo;
			_mapper = mapper;
			
		}


		public async  Task<PharmacyResponseDto> AddPharmacyAsync(PharmacyCreateDto dto)
		{
			 var pharmacy = _mapper.Map<Pharmacy>(dto);
			 await _pharmaRepo.AddAsync(pharmacy);
			 return _mapper.Map<PharmacyResponseDto>(pharmacy);
		}

		public async Task DeletePharmacyAsync(Guid id)
		{
			var pharmacy = await  _pharmaRepo.GetPharmacyByAsync(id) ?? throw new BusinessException("Farmacia não existe no banco de dados");
			await _pharmaRepo.DeleteAsync(pharmacy);
		}

		public async Task<PagedResult<PharmacyResponseDto>> GetPharmaciesAsync(PharmacyQueryParams queryParams)
		{
			var (pharmacies, totalCount) = await _pharmaRepo.GetListPharmaciesAsync(
			queryParams.Email,
		    queryParams.Cnpj,
			queryParams.Page,
            queryParams.PageSize
			);
		 var data = _mapper.Map<List<PharmacyResponseDto>>(pharmacies);
		 return new PagedResult<PharmacyResponseDto>(data,queryParams.Page,queryParams.PageSize,totalCount);





		}

		public async  Task<PharmacyResponseDto> GetPharmacyId(Guid id)
		{
			var pharmacy = await  _pharmaRepo.GetPharmacyByAsync(id) ?? throw new BusinessException("Farmacia não existe no banco de dados");
			return pharmacy != null ? _mapper.Map<PharmacyResponseDto>(pharmacy) : null;
		}

		public async  Task PatchPharmacyAsync(Guid id, PharmacyPatchDto dto)
		{
			 var pharmacy = await _pharmaRepo.GetPharmacyByAsync(id) ?? throw new BusinessException("Farmacia com id não existe");
			 dto.Adapt<Pharmacy>();
			 await _pharmaRepo.PacthASync(id,
			 dto.Name, 
			 dto.Cnpj, 
			 dto.City, 
			 dto.State, 
			 dto.Address, 
			 dto.LogoUrl,
			 dto.Phone, 
			 dto.Email,
			 dto.PassHash, 
			 dto.Status
			 
			 );
		}
	}
}
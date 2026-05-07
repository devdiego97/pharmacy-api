using Application.DTOS.Category;
using Application.DTOS.PharmacyDto;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    public class PharmacyMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
		{
		     config.NewConfig<PharmacyCreateDto, Pharmacy>()
				.MapWith(src => new Pharmacy(
					src.idAdmin,
					src.Name,
					src.Cnpj, 
					src.City,
					src.State,
					src.Address,
					src.LogoUrl,
					src.Phone,
					src.Email,
					src.PassHash,
					true
				));

		   config.NewConfig<Pharmacy, PharmacyResponseDto>()
		    .MapWith(src => new PharmacyResponseDto(
				   src.Id,
			       src.IdAdmin,
			       src.Name,
					src.Cnpj, 
					src.City,
					src.State,
					src.Address,
					src.LogoUrl,
					src.Phone,
					src.Email,
					src.PassHash,
					src.Status,
					src.Categories != null ? src.Categories.Select(c => c.Adapt<CategoryResponseDto>()).ToList() : null
		   ));

		   // PharmacyPatchDto não deve ser mapeado para Pharmacy
		   // O PATCH deve atualizar a entidade existente, não criar uma nova
		}
    }
}
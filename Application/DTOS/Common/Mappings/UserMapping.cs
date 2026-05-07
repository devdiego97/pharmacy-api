
using Application.DTOS.UserDto;
using Domain.Entities;
using Mapster;


namespace Application.DTOS.Common.Mappings
{
    public class UserMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
         config.NewConfig<User, UserResponseDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Role, src => src.Role)
                .Map(dest => dest.PassHash,src=>src.PassHash)
                // Mapear coleção de Pharmacies (relacionamento)
                .Map(dest => dest.Pharmacies, src => src.Pharmacies);
           
				  // ========================================
            // UserCreateDto → User
            // ========================================
            config.NewConfig<UserCreateDto, User>()
                .MapWith(src => new User(
                    src.name,
                    src.lastName,
                    src.email,
                    src.passHash,
                    src.role
                ));

            // ========================================
            // UserPatchDto → User (Atualização Parcial)
            // ========================================
           TypeAdapterConfig<UserPatchDto, User>
			.NewConfig()
			.IgnoreNullValues(true)
			.IgnoreIf((src, _) => string.IsNullOrWhiteSpace(src.name), dest => dest.Name)
			.IgnoreIf((src, _) => string.IsNullOrWhiteSpace(src.lastName), dest => dest.LastName)
			.IgnoreIf((src, _) => string.IsNullOrWhiteSpace(src.email), dest => dest.Email)
			.IgnoreIf((src, _) => string.IsNullOrWhiteSpace(src.passHash), dest => dest.PassHash);
        
        }
    }
}
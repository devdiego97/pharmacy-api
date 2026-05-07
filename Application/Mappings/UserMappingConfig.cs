using Application.DTOS.PharmacyDto;
using Application.DTOS.UserDto;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    /// <summary>
    /// Configurações de mapeamento para a entidade User.
    /// </summary>
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
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

            config.NewConfig<User, UserResponseDto>()
                .MapWith(src => new UserResponseDto(
                    src.Id,
                    src.Name,
                    src.LastName,
                    src.Email,
                    src.PassHash,
                    src.Role,
                    src.Pharmacies != null ? src.Pharmacies.Select(p => p.Adapt<PharmacyResponseDto>()).ToList() : null
                ));

            // ========================================
            // UserPatchDto → User (Atualização Parcial)
            // ========================================
            config.NewConfig<UserPatchDto, User>()
                .IgnoreNullValues(true) // Ignora propriedades null no DTO
                .Map(dest => dest.Name, src => src.name)
                .Map(dest => dest.LastName, src => src.lastName)
                .Map(dest => dest.Email, src => src.email)
                // Não permitir atualização de senha via Patch
                .Ignore(dest => dest.PassHash);
        }
    }
}

using Application.DTOS.shared;
using pharmacy_api.Enum;

namespace Application.DTOS.UserDto
{
    /// <summary>
    /// Parâmetros de filtragem e paginação para listagem de usuários.
    /// </summary>
    public record UserQueryParams : GenericQueryParams
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public UserRole? Role { get; init; }

       
    }
}

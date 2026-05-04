using Application.DTOS.Common;
using Application.DTOS.UserDto;


namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserResponseDto>> GetUsersAsync(UserQueryParams queryParams);
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<UserResponseDto> CreateUser(UserCreateDto dto);
        Task DeleteUser(Guid id);
        Task PatchUser(Guid id, UserPatchDto dto);
    }
}
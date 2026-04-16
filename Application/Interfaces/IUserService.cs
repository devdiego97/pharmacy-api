using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.User;

namespace Application.Interfaces
{
    public interface  IUserService
    {
        Task<IEnumerable<UserResponseDto>> GelAllAsync();
		Task<UserResponseDto> GetUserByIdAsync(Guid id);
		Task<UserResponseDto>  CreateUser(UserCreateDto dto);
		Task DeleteUser(Guid id);
		Task PatchUser(Guid id, UserPatchDto dto);
	
    }
}
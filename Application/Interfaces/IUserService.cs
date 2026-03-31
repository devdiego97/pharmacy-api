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
		Task<UserResponseDto>  CreateUser(UserCreateDto dto);
    }
}
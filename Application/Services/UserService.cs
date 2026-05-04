using Application.DTOS.Category;
using Application.DTOS.Common;
using Application.DTOS.PharmacyDto;
using Application.DTOS.UserDto;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo,IMapper mapper)
		{
			_userRepo = userRepo;
			_mapper = mapper;
		} 

        public async Task<PagedResult<UserResponseDto>> GetUsersAsync(UserQueryParams queryParams)
        {
            var (users, totalCount) = await _userRepo.GetUsersAsync(
                queryParams.Name,
                queryParams.Email,
                queryParams.Role.HasValue ? (int)queryParams.Role.Value : null,
                queryParams.Page,
                queryParams.PageSize
            );

           
			 var data = _mapper.Map<List<UserResponseDto>>(users);
             return new PagedResult<UserResponseDto>(data, queryParams.Page, queryParams.PageSize, totalCount);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepo.GetUserById(id)
                ?? throw new BusinessException("Usuário com o id não encontrado");

           return user != null ? _mapper.Map<UserResponseDto>(user) : null;
        }

        public async Task<UserResponseDto> CreateUser(UserCreateDto dto)
        {
           
			 var user = _mapper.Map<User>(dto);
             await _userRepo.AddAsync(user);
             return _mapper.Map<UserResponseDto>(user);
        }

        public async Task PatchUser(Guid id, UserPatchDto dto)
        {
            var user = await _userRepo.GetUserById(id)
                ?? throw new BusinessException("Usuário não encontrado");
			dto.Adapt<User>();
            await _userRepo.PatchAsync(id,dto.name,dto.lastName,dto.email,dto.passHash);
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _userRepo.GetUserById(id)
                ?? throw new BusinessException("Usuário não existe no banco de dados");

            await _userRepo.DeleteAsync(user);
        }

	}
}
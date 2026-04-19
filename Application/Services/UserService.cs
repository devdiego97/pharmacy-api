using Application.DTOS.Category;
using Application.DTOS.Common;
using Application.DTOS.Pharmacy;
using Application.DTOS.User;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo) => _userRepo = userRepo;

        public async Task<PagedResult<UserResponseDto>> GetUsersAsync(UserQueryParams queryParams)
        {
            var (users, totalCount) = await _userRepo.GetUsersAsync(
                queryParams.Name,
                queryParams.Email,
                queryParams.Role.HasValue ? (int)queryParams.Role.Value : null,
                queryParams.Page,
                queryParams.PageSize
            );

            var data = users.Select(MapToDto);

            return new PagedResult<UserResponseDto>(data, queryParams.Page, queryParams.PageSize, totalCount);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepo.GetUserById(id)
                ?? throw new BusinessException("Usuário com o id não encontrado");

            return MapToDto(user);
        }

        public async Task<UserResponseDto> CreateUser(UserCreateDto dto)
        {
            var user = new User(dto.name, dto.lastName, dto.email, dto.passHash, dto.role);
            await _userRepo.AddAsync(user);
            return new UserResponseDto(user.Id, user.Name, user.LastName, user.Email, user.PassHash, user.Role, null);
        }

        public async Task PatchUser(Guid id, UserPatchDto dto)
        {
            _ = await _userRepo.GetUserById(id)
                ?? throw new BusinessException("Usuário não encontrado");

            await _userRepo.PatchAsync(id, dto.name, dto.lastName, dto.email, dto.passHash);
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _userRepo.GetUserById(id)
                ?? throw new BusinessException("Usuário não existe no banco de dados");

            await _userRepo.DeleteAsync(user);
        }

        // Mapeamento centralizado — evita repetição nos métodos acima
        private static UserResponseDto MapToDto(User u) =>
            new(
                u.Id, u.Name, u.LastName, u.Email, u.PassHash, u.Role,
                u.Pharmacies?.Select(p => new PharmacyResponseDto(
                    p.IdAdmin, p.Name, p.Cnpj, p.City, p.State, p.Address,
                    p.LogoUrl, p.Phone, p.Email, p.PassHash, p.Status,
                    p.Categories.Select(c => new CategoryResponseDto(c.Id, c.Name, c.Description)).ToList()
                )).ToList()
            );
    }
}
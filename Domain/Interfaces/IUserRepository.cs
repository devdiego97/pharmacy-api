using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Retorna usuários paginados e filtrados diretamente no banco.
        /// </summary>
        Task<(IEnumerable<User> Users, int TotalCount)> GetUsersAsync(
            string? name,
            string? email,
            int? role,
            int page,
            int pageSize);

        Task<User?> GetUserById(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task PatchAsync(Guid id, string? name, string? lastName, string? email, string? passHash);
        Task DeleteAsync(User user);
    }
}
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext ctx) => context = ctx;

        public async Task<(IEnumerable<User> Users, int TotalCount)> GetUsersAsync(
            string? name,
            string? email,
            int? role,
            int page,
            int pageSize)
        {
            // IQueryable: a query só vai ao banco quando ToListAsync/CountAsync for chamado
            var query = context.Users
                .Include(u => u.Pharmacies)
                    .ThenInclude(p => p.Categories)
                .AsQueryable();

            // Cada filtro adiciona um WHERE apenas se o parâmetro foi informado
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(u => u.Name.Contains(name) || u.LastName.Contains(name));

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(u => u.Email.Contains(email));

            if (role.HasValue)
                query = query.Where(u => (int)u.Role == role.Value);

            // Executa duas queries otimizadas no banco
            var totalCount = await query.CountAsync();

            var users = await query
                .OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (users, totalCount);
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await context.Users
                .Include(u => u.Pharmacies)
                    .ThenInclude(p => p.Categories)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public Task UpdateAsync(User user) => throw new NotImplementedException();

        public async Task PatchAsync(Guid id, string? name, string? lastName, string? email, string? passHash)
        {
            await context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(setters =>
                    setters
                        .SetProperty(u => u.Name,     u => name     ?? u.Name)
                        .SetProperty(u => u.LastName, u => lastName ?? u.LastName)
                        .SetProperty(u => u.Email,    u => email    ?? u.Email)
                        .SetProperty(u => u.PassHash, u => passHash ?? u.PassHash)
                );
        }

        public async Task DeleteAsync(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
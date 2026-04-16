using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{

		private readonly AppDbContext context;

		public UserRepository(AppDbContext ctx)=>context=ctx;

		public async Task AddAsync(User user)
		{
			
			  await context.Users.AddAsync(user);
			  await context.SaveChangesAsync();

		}

	

		public async Task DeleteAsync(User user)
		{
		    context.Users.Remove(user);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> GetAllUsers()
		{
		    // return await context.Users .Include(u => u.Pharmacies).ToListAsync();

			return await context.Users
				.Include(u => u.Pharmacies)
					.ThenInclude(p => p.Categories)
				.ToListAsync();
		}

		
		

		public async  Task<User> GetUserById(Guid id)
		{
			/* var user= await context.Users.FindAsync(id); nao érmite o inlude
			var user = await context.Users
			.Include(u => u.Pharmacies)
			.SingleOrDefaultAsync(u => u.Id == id);  */

			var user = await context.Users
        .Include(u => u.Pharmacies)
            .ThenInclude(p => p.Categories)
        .SingleOrDefaultAsync(u => u.Id == id);

			return user;
		}

		public Task UpdateAsync(User user)
		{
			throw new NotImplementedException();
		}

		public async Task PatchAsync(Guid id, string? name, string? lastName, string? email, string? passHash)
		{
			await context.Users
				.Where(u => u.Id == id)
				.ExecuteUpdateAsync(setters =>
					setters
						.SetProperty(u => u.Name,      u => name      ?? u.Name)
						.SetProperty(u => u.LastName,  u => lastName  ?? u.LastName)
						.SetProperty(u => u.Email,     u => email     ?? u.Email)
						.SetProperty(u => u.PassHash,  u => passHash  ?? u.PassHash)
				);
		}

		
	}
}
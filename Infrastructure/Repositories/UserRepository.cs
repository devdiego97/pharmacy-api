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

		public async Task deleteAsync(Guid id)
		{
		   await context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
		}

		public async Task<IEnumerable<User>> GetAllUsers()
		{
		   return await context.Users .Include(u => u.Pharmacies).ToListAsync();
		}

		public async  Task<User> GetUserById(Guid id)
		{

			var user=await context.Users.FindAsync(id);
		    return user!;

		}

		public async Task UpdateAsync(User user)
		{
			
			  context.Users.Update(user);
			  await context.SaveChangesAsync();

		}
	}
}
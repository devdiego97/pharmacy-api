using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using pharmacy_api.Enum;

namespace Infrastructure.Seed
{
    public class UserSeed
    {
        public static async  Task SeedAsync(AppDbContext context){

		
			var users = new List<User>()
			{
			    new User("Diego","Dutra Morais", "diegodm97@gmail.com","hweghweewferrrr",UserRole.Admin),
				new User("Àgata","Gomes Sousa", "agatagomessousa@gmail.com","hweghweewferrrr",UserRole.Admin),
				new User("Sara","Moreira","saramoreira@gmail.com","fdsederrehur",UserRole.Client),
				new User("Mara","Morais","maramorais@gmail.com","fdsederrehur",UserRole.Client),
				new User("Igor","Moura","igormoura@gmail.com","fdsederrehur",UserRole.Client),
				new User("Bruno","Pereira","brunopereira@gmail.com","fdsederrehur",UserRole.Client),
				new User("Tiago","Santos","tiagosantosa@gmail.com","fdsederrehur",UserRole.Client),
				new User("Ingrid","Moreira","ingridmoreira@gmail.com","fdsederrehur",UserRole.Client),
				new User("Diego","Dutra Morais", "diegodmdde97@gmail.com","hweghweewferrrr",UserRole.Admin),
				new User("Àgata","Gomes Sousa", "agatagomeeewssousa@gmail.com","hweghweewferrrr",UserRole.Admin),
				new User("Sara","Moreira","saramoreirwwa@gmail.com","fdsederrehur",UserRole.Client),
				new User("Mara","Morais","maramoraiswweew@gmail.com","fdsederrehur",UserRole.Client),
				new User("Igor","Moura","igormourawewee@gmail.com","fdsederrehur",UserRole.Client),
				new User("Bruno","Pereira","brunopereirweddfa@gmail.com","fdsederrehur",UserRole.Client),
				new User("Tiago","Santos","tiagosantosfdsdsda@gmail.com","fdsederrehur",UserRole.Client),
				new User("Ingrid","Moreira","ingridmoreirsddsdsdsa@gmail.com","fdsederrehur",UserRole.Client)
				
			};

				var existingEmails = await context.Users
		.Select(u => u.Email)
		.ToListAsync();

		var usersToAdd = users
			.Where(u => !existingEmails.Contains(u.Email))
			.ToList();

		if (usersToAdd.Any())
		{
			context.Users.AddRange(usersToAdd);
			await context.SaveChangesAsync();
}

		


		}
    }
}
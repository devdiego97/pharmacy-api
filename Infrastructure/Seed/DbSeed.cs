using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Seed.Modules;
using pharmacy_api.Enum;
using Polly;

namespace Infrastructure.Seed
{
    public class DbSeed
    {
        public static async Task SeedAsync(AppDbContext contextDb)
		{

		   await UserSeed.SeedAsync(contextDb);
		   await PharmacySeed.SeedAsync(contextDb);
		   await CategorySeed.SeedAsync(contextDb);
		   await MedicamentionSeed.SeedAsync(contextDb);

		}
    }
}
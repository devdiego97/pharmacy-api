using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed.Modules
{
    public class CategorySeed
    {
        public static async Task SeedAsync(AppDbContext context)
		{
			
			var  pharmacy=await context.Pharmacies.FirstOrDefaultAsync(e=>e.Email == "saudeBaoD+@gmail.com");

			if(pharmacy != null)
			{
				var categories= new List<Category>
				{
					new Category(pharmacy.Id,"Higiene","produtos de higiene"),
					new Category(pharmacy.Id,"Infantil","produtos para bebês e crianças"),
					new Category(pharmacy.Id,"Genéricos","medicamentos genericos")

					
				};
				 context.Categories.AddRange(categories);
               await context.SaveChangesAsync();
				
			}
			
		}
    }
}
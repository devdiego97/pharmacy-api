using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed.Modules
{
    public class PharmacySeed
    {
        public static async Task SeedAsync(AppDbContext context)
		{

			var admin = await context.Users.FirstOrDefaultAsync(u => u.Email == "diegodm97@gmail.com");
			var admin2 = await context.Users.FirstOrDefaultAsync(u => u.Email == "agatagomessousa@gmail.com");
            
			if(admin != null)
			{
				var pharmacies=new List<Pharmacy>
				{
					new Pharmacy(admin.Id,"Saude+", "12345678000195","Rubim","MG", "Rua curitiba,156,Bairro Upe",null,"11987654321","saude+@gmail.com","gswtywevgeghdgewft2235656",true),
					new Pharmacy(admin2.Id,"SaudeBaoD+", "12345678000185","São Paulo","SP", "Rua curitiba,156,Bairro Upe",null,"11987654325","saudeBaoD+@gmail.com","gswtywevgeghdgewft2235656",true)

					
				};
				 context.Pharmacies.AddRange(pharmacies);
                await context.SaveChangesAsync();
				
			}


		}
    }
}
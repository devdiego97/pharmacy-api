using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using pharmacy_api.Enum;

namespace Infrastructure.Seed.Modules
{
    public class MedicamentionSeed
    {
        public static async Task SeedAsync(AppDbContext context)
		{
			
		  var category=await context.Categories.FirstOrDefaultAsync(e=>e.Name == "Genéricos" );


			if(category != null)
			{
				 var medicaments= new List<Medication>
					{
						
						new Medication(category.Id,"Paracetamol","Analgésico e antitérmico usado para dor leve a moderada e febre.","EMS", 12.50m,"https://example.com/paracetamol.jpg","dor, febre, comum","500mg a cada 6-8 horas",false,ETypeMedicament.Analgésicos),
						new Medication(category.Id,"Aspirina","Ácido acetilsalicílico usado para dor, febre e como antiplaquetário.","Bayer",14.50m,"https://example.com/aspirina.jpg","dor, febre, comum","500mg a cada 4-6 horas",false,ETypeMedicament.Analgésicos),
						new Medication(category.Id, "Tramadol","Analgésico opioide usado para dores moderadas a severas.","Eurofarma",17.50m,"https://example.com/tramadol.jpg","dor, febre, comum","50-100mg a cada 4-6 horas",true,ETypeMedicament.Analgésicos),
						new Medication(category.Id, "Ibuprofeno", "Anti-inflamatório não esteroidal (AINE) usado para dor, inflamação e febre.","Eurofarma",18.50m,"https://example.com/ibuprofeno.jpg","dor, febre, comum","50-100mg a cada 4-6 horas",false,ETypeMedicament.Anti_inflamatórios)
							
						
					};
			
			context.Medications.AddRange(medicaments);
			await context.SaveChangesAsync();
				
			}
		   




			
		}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Repositories
{
	public class PharmacyRepository : IPharmacyRepository
	{

		private readonly AppDbContext _context;

		public PharmacyRepository(AppDbContext ctx)=>_context=ctx;




		public async  Task AddAsync(Pharmacy pharmacy)
		{
			await _context.AddAsync(pharmacy);
			await _context.SaveChangesAsync();
		}

		public async  Task DeleteAsync(Pharmacy pharmacy)
		{
			_context.Pharmacies.Remove(pharmacy);
			await _context.SaveChangesAsync();
		}
		public async Task<(IEnumerable<Pharmacy> Pharmscies, int TotalCount)> GetListPharmaciesAsync(
			string? Email, string? Cnpj, int page, int pageSize
		)
		{
		  

		   var query=_context.Pharmacies.Include(u=>u.Categories).AsQueryable();
		   
		   if(!string.IsNullOrWhiteSpace(Email))
		    query=query.Where(u=>u.Email.Contains(Email));

	      if(!string.IsNullOrWhiteSpace(Cnpj))
		   query=query.Where(u=>u.Cnpj.Contains(Cnpj));

			var totalCount=await query.CountAsync();
			var pharmacies=await query
			.OrderBy(p=>p.Name)
			.Skip((page -1) * pageSize)
			.Take(pageSize)
			.ToListAsync();

			return (pharmacies,totalCount);


		}

		public Task<Pharmacy?> GetPharmacyByAsync(Guid id)
		{
			return _context.Pharmacies
			.Include( p => p.Categories)
			.SingleOrDefaultAsync(p=>p.Id == id);
		}

		public async Task PacthASync(Guid id, string? name, string? cnpj, string? 
			city, string? state, string? address, string? logoUrl, string? 
			phone, string? email, string? passHash, bool? status
	   )
		{
		  await _context.Pharmacies
		  .Where(p => p.Id == id)
		  .ExecuteUpdateAsync(setters =>
		  	setters
			.SetProperty(p => p.Name , p =>name ?? p.Name )
			.SetProperty(p => p.Cnpj , p =>cnpj ?? p.Cnpj )
			.SetProperty(p => p.City, p =>city ?? p.City )
			.SetProperty(p => p.State, p =>state ?? p.State )
			.SetProperty(p => p.Address , p =>address ?? p.Address )
			.SetProperty(p => p.Phone , p =>phone ?? p.Phone )
			.SetProperty(p => p.Email , p =>email ?? p.Email )
			.SetProperty(p => p.PassHash , p =>passHash ?? p.PassHash )
			.SetProperty(p => p.Status, p =>status ?? p.Status )
     );

		}
	}
}
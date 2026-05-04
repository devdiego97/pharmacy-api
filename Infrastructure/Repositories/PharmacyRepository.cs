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




		public Task AddAsync(Pharmacy pharmacy)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Pharmacy pharmacy)
		{
			throw new NotImplementedException();
		}

		public async Task<(IEnumerable<Pharmacy> Pharmscies, int TotalCount)> GetListPharmaciesAsync(string? Email, string? Cnpj, int page, int pageSize)
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
			.TakeLast(pageSize)
			.ToListAsync();

			return (pharmacies,totalCount);


		}

		public Task<Pharmacy?> GetPharmacyByAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task PacthASync(Guid id, string? name, string? cnpj, string? city, string? state, string? address, string? logoUrl, string? phone, string? email, string? passHash, bool? status)
		{
			throw new NotImplementedException();
		}
	}
}
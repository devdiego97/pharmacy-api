using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPharmacyRepository
    {
        Task<(IEnumerable<Pharmacy> Pharmscies, int TotalCount)> GetListPharmaciesAsync(
		    string? Email,
            string? Cnpj,
            int page,
            int pageSize
		);
  Task<Pharmacy?> GetPharmacyByAsync(Guid id);
  Task AddAsync(Pharmacy pharmacy);
  Task PacthASync(Guid id,string? name,string? cnpj,string? city,string? state,
	string? address,string? logoUrl,string? phone,string? email,string? passHash,bool? status );

 Task DeleteAsync(Pharmacy pharmacy);



    }
}
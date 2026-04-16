using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
       Task<IEnumerable<User>> GetAllUsers() ;
	   Task<User> GetUserById(Guid id);
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task PatchAsync(Guid id, string? name, string? lastName, string? email, string? passHash);
		Task DeleteAsync(User user);
		


    };

}
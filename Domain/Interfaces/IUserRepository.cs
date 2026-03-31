using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
       Task<IEnumerable<User>> GetAllUsers() ;
	   Task<User> GetUserById(Guid id);
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task deleteAsync(Guid id);


    };

}
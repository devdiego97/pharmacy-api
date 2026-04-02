using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.Pharmacy;
using Application.DTOS.User;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;


		public UserService(IUserRepository userRepo)=>_userRepo=userRepo;

	

		public async Task<UserResponseDto> CreateUser(UserCreateDto dto)
		{
			var user=new User(
                 dto.name,dto.lastName,dto.email,dto.passHash,dto.role
			);
			await _userRepo.AddAsync(user);
			return  new UserResponseDto(
				user.Id,user.Name,user.LastName,user.Email,user.PassHash,user.Role,null
			);
		

		}


		public async  Task<IEnumerable<UserResponseDto>> GelAllAsync()
		{
			var users= await _userRepo.GetAllUsers();
			return  users.Select(u => new UserResponseDto(
			  u.Id,u.Name,u.LastName,u.Email,u.PassHash,u.Role,
			  u.Pharmacies?.Select(p => new PharmacyResponseDto(
				p.IdAdmin,p.Name,p.Cnpj,p.City,p.State,p.Address,p.LogoUrl,p.Phone,p.Email,p.PassHash,p.Status,p.Categories
			  )).ToList()
			));
		}

		public async Task<UserResponseDto> getUserByIdAsync(Guid id)
		{
		  var user=await _userRepo.GetUserById(id);
		  return new UserResponseDto( user.Id,user.Name,user.LastName,user.Email,user.PassHash,user.Role,null);

		}
		 
	}
}
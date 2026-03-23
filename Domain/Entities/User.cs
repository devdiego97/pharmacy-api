using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using pharmacy_api.Enum;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name{get;private set;}=string.Empty;
		public string LastName{get; private set;}=string.Empty;
		public string Email{get; private set;}=string.Empty;
		public  string PassHash{get;private set;}=string.Empty;
		public  UserRole Role{get;private set;}=UserRole.subAdmin;
		public Pharmacy? Pharmacy=null!;

		protected User(){}
		public User(string name,string lastName,string email,string passHash,UserRole role)
		{
			this.Name=name;
			this.LastName=lastName;
			this.Email=email;
			this.PassHash=passHash;
			this.Role=role;

		}

	}
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class Pharmacy : BaseEntity
    {
		public  Guid IdAdmin{get; private set;}
		public User Admin{get; private set;}
        public  string Name{get;private set;}=string.Empty;
		public string Cnpj{get; private set;}=string.Empty;
		public  string City{get; private set;}=string.Empty;
		public string State{get;private set;}=string.Empty;
		public  string Address{get;private set;}=string.Empty;
		public string? LogoUrl{get;private set;}=null!;
		public string Phone{get;private set;}=string.Empty;
		public string Email{get; private set;}=string.Empty;
		public  string PassHash{get; private set;}=string.Empty;
		public bool Status{get; private set;}
	   
		 public ICollection<Category> Categories { get; set; } = new List<Category>();

		 public Pharmacy(Guid idAdmin,string name,string cnpj,string city,string state,string address,
		  string? logoUrl, string phone, string email,string passHash,bool status
		)
		{
			this.IdAdmin=idAdmin;
			this.Name=name;
			this.Cnpj=cnpj;
			this.City=city;
			this.State=state;
			this.Address=address;
			this.LogoUrl=logoUrl;
			this.Phone=phone;
			this.Email=email;
			this.PassHash=passHash;
			this.Status=status;


		}
	
	protected Pharmacy()
		{
			
		}



    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy_api.Entities
{
    public class Pharmacy : Base
    {
		public  Guid idAdmin{get;set;}
		public User admin{get;set;}
        public  string name{get;set;}=string.Empty;
		public string cnpj{get;set;}=string.Empty;
		public  string city{get;set;}=string.Empty;
		public string state{get;set;}=string.Empty;
		public  string address{get;set;}=string.Empty;
		public string? logoUrl{get;set;}=null!;
		public string phone{get;set;}=string.Empty;
		public string email{get;set;}=string.Empty;
		public  string passHash{get;set;}=string.Empty;
		public Boolean status{get;set;}
		 public ICollection<Category> Categories { get; set; } = new List<Category>();




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy_api.Entities
{
    public abstract  class Product : Base
    {
		public  Guid idPharmacy{get;set;}
		public Guid idCategory{get;set;}
        public  string name{get;set;}=string.Empty;
		public string description{get;set;}=string.Empty;
		public string manufacturer{get;set;}=string.Empty;
		public decimal price{get;set;}
		public int stock{get;set;}
        
        public string? imageurl{get;set;}=null!;
		public string? tags{get;set;}=null!;
	    public Category category{get;set;}
	

    }
}
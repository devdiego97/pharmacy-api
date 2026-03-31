using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract  class Product : BaseEntity
    {
		public  Guid? IdPharmacy{get;private set;}
		public Guid IdCategory{get;private set;}
        public  string Name{get;private set;}=string.Empty;
		public string Description{get;private set;}=string.Empty;
		public string Manufacturer{get;private set;}=string.Empty;
		public decimal Price{get;private set;}
		public int Stock{get;private set;}
        
        public string? ImageUrl{get;private set;}=null!;
		public string? Tags{get;private set;}=null!;
	    public Category Category{get;private set;}


		protected Product(){}
		protected Product(Guid idCategory,string name,string description,string manufacturer,decimal price,string? imageUrl,string? tags)
		{
		
			this.IdCategory=idCategory;
			this.Name=name;
			this.Description=description;
			this.Manufacturer=manufacturer;
			this.Price=price;
			this.ImageUrl=imageUrl;
			this.Tags=tags;
		}
		
	

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy_api.Entities
{
    public class Category : Base
    {

		public Guid idPharmacy{get;set;}=Guid.NewGuid();
		public Pharmacy pharmacy{get;set;}
        public string name{get;set;}=string.Empty;
		public string? description{get;set;}=string.Empty;

		public ICollection<Medication> medicaments{get;set;} = new List<Medication>();

    }
}
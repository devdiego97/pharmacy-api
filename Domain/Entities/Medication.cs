using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacy_api.Enum;

namespace Domain.Entities
{
    public class Medication : Product
    {
        public string? Dosage{get; private set;}=string.Empty;
		public bool? RequirePrescription{get; private set;}=false;
		public ETypeMedicament Type{get;private set;}=ETypeMedicament.Analgésicos;
		public Category? Category{get;private set;}
		
		protected  Medication()
		{
			
		}
	    public Medication(
			Guid idCategory,string name,string description,string manufacturer,decimal price,string? ImageUrl,string? tags,
			string? dosage,bool? requirePrescription,ETypeMedicament type)
			:base(idCategory,name,description,manufacturer,price,ImageUrl,tags)
		{
			this.Dosage=dosage;
			this.RequirePrescription=requirePrescription;
			this.Type=type;
		}

		
    }
}
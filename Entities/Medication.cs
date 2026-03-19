using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacy_api.Enum;

namespace pharmacy_api.Entities
{
    public class Medication : Product
    {
        public string? dosage{get;set;}=string.Empty;
		public bool? requirePrescription{get;set;}=false;
		public ETypeMedicament type{get;set;}=ETypeMedicament.Analgésicos;
		

		
    }
}
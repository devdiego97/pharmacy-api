using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharmacy_api.Enum;
namespace pharmacy_api.Entities
{
    public class User : Base
    {
        public string name{get;set;}=string.Empty;
		public string lastName{get;set;}=string.Empty;
		public string email{get;set;}=string.Empty;
		public  string passHash{get;set;}=string.Empty;
		public  UserRole role{get;set;}=UserRole.subAdmin;
		public Pharmacy? pharmacy=null!;
    }
}
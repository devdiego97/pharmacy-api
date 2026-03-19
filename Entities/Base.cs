using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy_api.Entities
{
    public abstract class Base
    {
       public Guid id{get;set;}=Guid.NewGuid();
	   public  DateTimeOffset createdAt{get;set;}=DateTimeOffset.UtcNow;
	   public  DateTimeOffset updatedA{get;set;}=DateTimeOffset.UtcNow;
    }
}
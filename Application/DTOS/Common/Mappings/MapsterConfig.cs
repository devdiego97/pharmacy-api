using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;




namespace Application.DTOS.Common.Mappings
{
    public class MapsterConfig : IRegister
    {
        public  void Register(TypeAdapterConfig  config)
		{
		   
			config.Default.PreserveReference(true);
			config.Default.IgnoreNullValues(false);

			new UserMapping().Register(config);
			

		}
    }
}
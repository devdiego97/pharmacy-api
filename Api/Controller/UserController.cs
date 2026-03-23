using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet()]
		public IActionResult GetUsersAll()
		{
		
			List<string> names= new List<string>{"Diego","Ana Maria","Bruna","Larissa"};
			return Ok(names);

			
		}
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pharmacy_api.Controller
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{
      
	  [HttpGet]
	  public IActionResult GetList()
		{
			 var names = new List<string> { "Diego", "Caio" };
            return Ok(names);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase 
    {

		private readonly IUserService _userService;
 
       public UserController(IUserService userService)=>_userService = userService;


	
      /// <summary>
	  /// Retorna uma lista  de usuarios
	  /// </summary>
	  /// <returns>Lista de usuarios</returns> 
	  /// <response code="200">Usuário retornados com sucesso</responde>
	  ///<response code="204">Nenhum usuário encontrado</responde>
        [HttpGet()]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
		public  async Task<IActionResult>  GetUsersAll()
		{
			var users=await _userService. GelAllAsync();

			if(users == null || !users.Any())
			   return NoContent();
			
			return Ok(users);
		}

		
      /// <summary>
	  ///Cria um novo usuário e retorna oi usuário criado
	  ///</summary>
	  ///<returns>Cria um novo usuário</returns> 
	  ///<response code="201">Usuário criado com sucesso</responde>
	  ///<response code="400">Dados inválidos</responde>
       [HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddNewUser([FromBody] UserCreateDto dto)
		{
			 if (!ModelState.IsValid)
              return BadRequest(ModelState);

			var user=await _userService.CreateUser(dto);
			return StatusCode(StatusCodes.Status201Created, user);
			
		}
    }


		

}
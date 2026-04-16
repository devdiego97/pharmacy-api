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

      ///<summary>
	  /// Retorna uma lista  de usuarios
	  ///</summary>
	  ///<returns>Lista de usuarios</returns> 
	  ///<response code="200">Usuário retornados com sucesso</responde>
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


     ///<summary>
	  /// Retorna um usuario pelo seu Id
	  ///</summary>
	  ///<returns>Lista de usuarios</returns> 
	  ///<response code="200">Usuário retornados com sucesso</responde>
	  ///<response code="204">Nenhum usuário encontrado</responde>
        [HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
		public  async Task<IActionResult>  GetUserById(Guid id)
		{
			var user=await _userService.GetUserByIdAsync(id);

			if(user == null)
			   return NoContent();
			
			return Ok(user);
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
        
		/// <summary>
		/// Atualiza parcialmente um usuário
		/// </summary>
		/// <param name="id">Identificador do usuário</param>
		/// <param name="dto">Campos a atualizar (apenas os preenchidos serão alterados)</param>
		/// <response code="200">Usuário atualizado com sucesso</response>
		/// <response code="404">Usuário não encontrado</response>
		[HttpPatch("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PatchUser(Guid id, [FromBody] UserPatchDto dto)
		{
			await _userService.PatchUser(id, dto);
			return Ok(new { message = "recurso alterado com sucesso" });
		}

		/// <summary>
		/// Deleta um usuário pelo seu id
		/// </summary>
		/// <param name="id">Identificador do usuário</param>
		/// <response code="204">Usuário deletado com sucesso</response>
		/// <response code="404">Usuário não encontrado</response>
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteUserById(Guid id)
		{
			await _userService.DeleteUser(id);
			return NoContent();
		}


    }


	

}
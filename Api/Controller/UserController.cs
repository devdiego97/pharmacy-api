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

        public UserController(IUserService userService) => _userService = userService;

        /// <summary>
        /// Retorna uma lista paginada de usuários com filtros opcionais.
        /// </summary>
        /// <param name="queryParams">Filtros: name, email, role. Paginação: page, pageSize (máx 100).</param>
        /// <response code="200">Usuários retornados com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryParams queryParams)
        {
            var result = await _userService.GetUsersAsync(queryParams);
            return Ok(result);
        }

        /// <summary>
        /// Retorna um usuário pelo seu Id.
        /// </summary>
        /// <response code="200">Usuário retornado com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewUser([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.CreateUser(dto);
            return StatusCode(StatusCodes.Status201Created, user);
        }

        /// <summary>
        /// Atualiza parcialmente um usuário.
        /// </summary>
        /// <response code="200">Usuário atualizado com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchUser(Guid id, [FromBody] UserPatchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.PatchUser(id, dto);
            return Ok(new { message = "Recurso alterado com sucesso" });
        }

        /// <summary>
        /// Deleta um usuário pelo seu Id.
        /// </summary>
        /// <response code="204">Usuário deletado com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
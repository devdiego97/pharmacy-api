using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOS.PharmacyDto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/pharmacies")]
    public class PharmacyController : ControllerBase
    {

		private readonly IPharmacyService _pharmaService;

		public PharmacyController(IPharmacyService pharmaService) => _pharmaService = pharmaService;

        /// <summary>
        /// Retorna uma lista paginada de farmacias com filtros opcionais.
        /// </summary>
        /// <param name="queryParams">Filtros:  email, cnpj . Paginação: page, pageSize (máx 100).</param>
        /// <response code="200">Farmacias retornadas com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListPharmacies([FromQuery] PharmacyQueryParams queryParams)
		{
			var result= await _pharmaService.GetPharmaciesAsync(queryParams);
			return Ok(result);
			
		}

		/// <summary>
        /// Retorna uma farmacia pelo seu Id.
        /// </summary>
        /// <response code="200">Farmacia retornada com sucesso</response>
        /// <response code="404">Farmacia não encontrada</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetPharmacyById(Guid id){
			var pharmacy =await _pharmaService.GetPharmacyId(id);
			return Ok(pharmacy);
		}
        /// <summary>
        /// Cria uma nova farmacia.
        /// </summary>
        /// <response code="201">Farmacia criada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddNewPharmacy([FromBody] PharmacyCreateDto dto)
		{
			if(!ModelState.IsValid)
			  return BadRequest(ModelState);
			var pharmacy = await _pharmaService.AddPharmacyAsync(dto);
			return StatusCode(StatusCodes.Status201Created , pharmacy);

		}

        /// <summary>
        /// Atualiza parcialmente uma farmacia
        /// </summary>
        /// <response code="200">Farmacia atualizado com sucesso</response>
        /// <response code="404">Farmacia não encontrada</response>
        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PatchPharmacyUpdate(Guid id, [FromBody] PharmacyPatchDto dto)
		{
			if(!ModelState.IsValid)
			  return BadRequest(ModelState);


			await _pharmaService.PatchPharmacyAsync(id,dto);
			return Ok(new {message = "Farmacia atualizada com sucesso"});
		}


		/// <summary>
		/// Deleta uma farmacia pelo seu Id.
		/// </summary>
		/// <response code="204">Farmacia deletado com sucesso</response>
		/// <response code="404">Farmacia não encontrada</response>
		[HttpDelete("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeletePharmacyById(Guid id){
				await _pharmaService.DeletePharmacyAsync(id);
				return NoContent();
		
		}

    }
}
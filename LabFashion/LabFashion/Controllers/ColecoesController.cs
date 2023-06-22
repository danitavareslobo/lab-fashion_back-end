using LabFashion.Models;
using LabFashion.Models.Enums;
using LabFashion.Models.ViewModels;
using LabFashion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabFashion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColecoesController : ControllerBase
    {
        private readonly IColecoesService _service;

        public ColecoesController(IColecoesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostColecao colecao)
        {
            try
            {
                var result = await _service.CreateAsync(colecao);

                if (result == null)
                    return Conflict("Nome da Coleção já cadastrado!");

                if (result == false)
                    return BadRequest("Dados inválidos!");

                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao criar coleção");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PutColecao colecao)
        {
            try
            {
                var result = await _service.UpdateAsync(colecao);

                if (result == null)
                    return NotFound("Coleção não encontrado");

                if (result == false)
                    return BadRequest("Erro ao alterar coleção");

                return Ok(colecao);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao alterar coleção");
            }
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EstadoSistema status)
        {
            try
            {
                var result = await _service.UpdateEstadoSistemaAsync(id, status);

                if (result == null)
                    return NotFound("Código/Estado no Sistema não encontrado");

                if (result == false)
                    return BadRequest("Dados Inválidos");

                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao alterar Estado da Coleção no Sistema");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EstadoSistema? status)
        {
            try
            {
                return Ok(await _service.GetAllAsync(status));
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao listar coleções");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao obter coleções");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                if (result == null)
                   return NotFound("Código não existente na base de dados");

                if (result == false) return BadRequest("Coleção não pôde ser excluída pois está ativa ou possui modelos vinculados");

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao excluir coleção");
            }
        }
    }
}

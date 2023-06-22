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
    public class ModelosController : ControllerBase
    {
        private readonly IModelosService _service;

        public ModelosController(IModelosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostModelo modelo)
        {
            try
            {
                var result = await _service.CreateAsync(modelo);

                if (result == null)
                    return Conflict("Nome do Modelo já cadastrado!");

                if (result == false)
                    return BadRequest("Dados inválidos!");

                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao criar modelo");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PostModelo modelo)
        {
            try
            {
                var result = await _service.UpdateAsync(modelo);

                if (result == null)
                    return NotFound("Modelo não encontrado");

                if (result == false)
                    return BadRequest("Erro ao alterar modelo");

                return Ok(modelo);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao alterar modelo");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Layout? layout)
        {
            try
            {
                return Ok(await _service.GetAllAsync(layout));
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao listar modelos");
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
                return BadRequest("Erro ao obter modelo");
            }
        }
    }
}

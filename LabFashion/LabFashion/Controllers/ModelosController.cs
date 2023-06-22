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
    }
}

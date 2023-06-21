﻿using LabFashion.Models.Enums;
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




    }
}

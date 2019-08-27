using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstilosController : ControllerBase
    {
        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstiloRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilos)
        {
            try
            {
                EstiloRepository.Cadastrar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos Estilos = EstiloRepository.BuscarPorId(id);
            if (Estilos == null)
                return NotFound();
            return Ok(Estilos);
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos Estilos)
        {
            try
            {
                Estilos EstilosBuscada = EstiloRepository.BuscarPorId(Estilos.IdEstilo);
                if (EstilosBuscada == null)

                    return NotFound();

                EstiloRepository.Atualizar(Estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
    }
}
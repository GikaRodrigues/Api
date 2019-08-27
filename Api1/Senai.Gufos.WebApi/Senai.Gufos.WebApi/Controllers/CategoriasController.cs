using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( new { mensagem = "Ih, deu erro" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }

        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                Categorias CategoriasBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (CategoriasBuscada == null)
               
                    return NotFound();

                CategoriaRepository.Atualizar(categoria);
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
            CategoriaRepository.Deletar(id);
            return Ok();
        }
    }
}
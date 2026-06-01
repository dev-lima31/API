using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        public static List<Filme> filmes = new List<Filme>()
        {
            new Filme{Id=1, Nome="fdp 2", DataLancamento="13/03/2012"},
            new Filme{Id=2, Nome="fdp 3", DataLancamento="10/10/2027"}
        };
        [HttpGet("ListarFilmes")]
        public ActionResult<Filme> ListarPorId(int id)
        {
            var busca = filmes.FirstOrDefault(b => b.Id == id);
            if (busca == null)
            {
                return NotFound(busca);
            }
            return Ok(busca);
        }
        [HttpPost("filmesAdd")]
        public ActionResult<IEnumerable<Filme>> PostLivros([FromBody] Filme novoFilme)
        {
            novoFilme.Id = filmes.Count + 1;
            filmes.Add(novoFilme);
            return CreatedAtAction(nameof(ListarPorId), new { id = novoFilme.Id }, novoFilme);
        }
        [HttpPut("uou/{id}")]
        public ActionResult<Filme> editarFilme(int id, Filme filme)
        {
            var busca = filmes.FirstOrDefault(b => b.Id == id);
            if (busca == null)
            {
                return NotFound("nadica");
            }
            busca.Nome = filme.Nome;
            busca.DataLancamento = filme.DataLancamento;
            return Ok(filmes);
        }
        [HttpDelete("excluirCliente/{id}")]
        public ActionResult<Filme> DeletarCliente(int id)
        {
            var busca = filmes.FirstOrDefault(b => b.Id == id);
            if (busca == null)
            {
                return NotFound(busca);
            }
            filmes.Remove(busca);
            return Ok(filmes);
        }
    }
}
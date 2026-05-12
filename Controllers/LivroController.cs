using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("lixo/[controller]")]
    public class LivroController : ControllerBase
    {
        private static List<Livro> livros = new List<Livro>()
        {
            new Livro{Id=1, Nome="aaaa", Lancamento=1200},
            new Livro{Id=2, Nome="bbbb", Lancamento=180},
            new Livro{Id=3, Nome="cccc", Lancamento=2100}
        };
        [HttpGet("contrato")]
        public ActionResult<IEnumerable<Livro>> GetPorId(int id)
        {
            var livroId = livros.FirstOrDefault(l => l.Id == id);
            return Ok(livroId);
        }
    }
}
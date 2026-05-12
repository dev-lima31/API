using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("nononono/[controller]")]
    public class AlunoController : ControllerBase
    {
        public static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno{Id=1, Nome="Aham", Idade=17},
            new Aluno{Id=2, Nome="Ahmmm", Idade=18888}
        };
        [HttpGet("Cafe/{id}")]
        public ActionResult<IEnumerable<Aluno>> GetId(int id)
        {
            var cafe = alunos.FirstOrDefault(a => a.Id == id);
            return cafe == null ? NotFound() : Ok(cafe);
        }
        [HttpPost("risada")]
        public ActionResult Post([FromBody] Aluno novoAluno)
        {
            novoAluno.Id = alunos.Count + 1;
            alunos.Add(novoAluno);
            return CreatedAtAction(nameof(GetId), new { id = novoAluno.Id }, novoAluno);
        }
        [HttpPost("para")]
        public Aluno post2([FromBody] Aluno novoAluno)
        {

            alunos.Add(novoAluno);
            return novoAluno;
        }
    }
}
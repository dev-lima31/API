using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("amazon/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        public static List<Funcionario> funcionarios = new List<Funcionario>()
        {
            new Funcionario{Id=1, Nome="Flecsa", Idade=200},
            new Funcionario{Id=2, Nome="Makonia", Idade=1520},
            new Funcionario{Id=3, Nome="Siringuela Carvalho", Idade=2000}
        };
        [HttpGet("buscarFunc/{id}")]
        public ActionResult<IEnumerable<Funcionario>> GetId(int id)
        {
            var busca = funcionarios.FirstOrDefault(si => si.Id == id);
            return busca == null ? NotFound() : Ok(busca);
        }
        [HttpPost("postarFunc")]
        public ActionResult<IEnumerable<Funcionario>> PostFunc([FromBody] Funcionario novofuncionario)
        {
            novofuncionario.Id = funcionarios.Count + 1;
            funcionarios.Add(novofuncionario);
            return CreatedAtAction(nameof(GetId), new {id = novofuncionario.Id}, novofuncionario);
        }
    }
}
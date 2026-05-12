using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("garrafa/cosca[controller]")]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente{Id=1, Nome="Nome1", Idade=13},
            new Cliente{Id=2, Nome="Nome2", Idade=23}
        };
        [HttpGet("Zoio")]
        public ActionResult<IEnumerable<Cliente>> GetTodos()
        {
            return Ok(clientes);
        }
        [HttpGet("Sim/{id}")]
        public ActionResult<IEnumerable<Cliente>> GetPorId(int id)
        {
            var eujativela = clientes.FirstOrDefault(n => n.Id == id);
            return Ok(eujativela);
        }
        [HttpPost("cesar")]
         public ActionResult Post([FromBody] Cliente novoClient)
        {
            novoClient.Id = clientes.Count + 1;
            clientes.Add(novoClient);
            return CreatedAtAction(nameof(GetPorId), new { id = novoClient.Id }, novoClient);
        }
    }
}
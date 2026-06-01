using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class CarroController : ControllerBase
    {
        public List<Carro> carros = new List<Carro>()
        {
            new Carro{Id=1, Marca="Citroen", Modelo="Opala", Ano=1981},
            new Carro{Id=2, Marca="Toyota", Modelo="Supra", Ano=1990}
        };
        [HttpGet("Id")]
        public ActionResult<IEnumerable<Carro>> GetId (int id)
        {
            var busca = carros.FirstOrDefault(b => b.Id == id);
            if(busca == null)
            {
                return NotFound(busca);
            }
            return Ok(busca);
        }
        [HttpPost("Post")]
        public ActionResult<IEnumerable<Carro>> PostarCarro(Carro carro)
        {
            
        }
    }
}
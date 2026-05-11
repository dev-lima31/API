using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("Vaccari/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>()
        {
            new Produto{Id=1, Nome="Cacete", Preco=1200},
            new Produto{Id=2, Nome="Caralho", Preco=1800}
        };
    [HttpGet("Homi/{id}")]
    public ActionResult<IEnumerable<Produto>> GetPorId(int id)
        {
            var IdProduto = produtos.FirstOrDefault(p => p.Id == id);
            if(IdProduto.Id == null)
            {
                return NotFound(IdProduto);
            }
            return Ok(IdProduto);
        }
    [HttpGet("Arroz")]
     public ActionResult<IEnumerable<Produto>> GetTodos()
        {
            return Ok(produtos);
        }
    [HttpGet("feijao/{preco}")]
    public ActionResult<IEnumerable<Produto>> AcimadeCem(double preco)
        {
            for(int i = 1, i)
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using não_entendo_mais_nada.Models;

namespace não_entendo_mais_nada.Controllers
{
    [ApiController]
    [Route("Vaccari/[controller]")]
    public class ProdutosController : ControllerBase
    {
        public static List<Produto> produtos = new List<Produto>()
        {
            new Produto{Id=1, Nome="", Preco=1200},
            new Produto{Id=2, Nome="Caralho", Preco=10},
            new Produto{Id=3, Nome="numsouhomi", Preco=1}
        };
        [HttpGet("Homi/{id}")]
        public ActionResult<IEnumerable<Produto>> GetPorId(int id)
        {
            var IdProduto = produtos.FirstOrDefault(p => p.Id == id);
            if (IdProduto.Id == null)
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
        [HttpGet("feijao/{gaia}")]
        public ActionResult<IEnumerable<Produto>> GetAcima(double gaia)
        {
            var vaccari = produtos.Where(p => p.Preco > gaia).ToList();
            return Ok(vaccari);
        }
        [HttpGet("merda/{nome}")]
        public ActionResult<IEnumerable<Produto>> GetNome(string nome)
        {
            var nomezin = produtos.Where(p => p.Nome == nome).ToList();
            return Ok(nomezin);
        }
        [HttpPost("risada")]
        public ActionResult Post([FromBody] Produto novoItem)
        {
            novoItem.Id = produtos.Count + 1;
            produtos.Add(novoItem);
            return CreatedAtAction(nameof(GetPorId), new { id = novoItem.Id }, novoItem);
        }
        [HttpPut("67/{id}")]
        public ActionResult<IEnumerable<Produto>> Atualizar(int id, Produto produto)
        {
            var sim = produtos.FirstOrDefault(p => p.Id == id);

            if (sim == null)
            {
                return NotFound("Nada");
            }

            sim.Nome = produto.Nome;

            return Ok(sim);
        }
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Produto>> AtualizarPreco(int id, Produto produto)
        {
            var sim = produtos.FirstOrDefault(p => p.Id == id);

            if (sim == null)
            {
                return NotFound("Nada");
            }

            sim.Preco = produto.Preco;

            return Ok(sim);
        }
        [HttpPut("estoque/{id}")]
        public ActionResult<IEnumerable<Produto>> AtualizarQuant(int id, Produto produto)
        {
            var sim = produtos.FirstOrDefault(p => p.Id == id);

            if (sim == null)
            {
                return NotFound("Nada");
            }

            sim.Quantidade = produto.Quantidade;

            return Ok(sim);
        }
        [HttpDelete("apagar/{id}")]
        public ActionResult<Produto> DeletarProduto(int id)
        {
            var busca = produtos.FirstOrDefault(b => b.Id == id);
            if(busca == null)
            {
                return NotFound(busca);
            }
            produtos.Remove(busca);
            return Ok(produtos);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using ProdutosApiAula.Models;
using ProdutosApiAula.Repositories;

namespace ProdutosApiAula.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        [HttpGet(Name = "GetProduto")]
        public IEnumerable<Produto> Get()
        {
            return MockDB.GetProdutos();
        }

        [HttpGet("{id}")]
        public Produto GetProduto(int id)
        {
            return MockDB.GetProduto(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            MockDB.Produtos.Add(produto);
            return CreatedAtRoute("GetProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            var existingProduto = MockDB.GetProduto(id);
            if (existingProduto == null)
            {
                return NotFound();
            }
            produto.Id = id;
            MockDB.UpdateProduto(produto);
            return CreatedAtRoute("GetProduto", new { id = produto.Id }, produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] Produto produto)
        {
            var existingProduto = MockDB.GetProduto(id);
            if (existingProduto == null)
            {
                return NotFound();
            }
            MockDB.DeleteProduto(id);
            return Ok(new { message = "Produto deletado com sucesso.", existingProduto });
        }
    }
}

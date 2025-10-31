using CMCapitalTesteController.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CMCapitalAvaliacao.Services.Interfaces;
using CMCapitalAvaliacao.Services;

namespace CMCapitalTeste.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ListarProdutos());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Produto =  _service.BuscaProduto(id);
            return Produto.Value == null ? NotFound() : Ok(Produto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProdutoBO Produto)
        {
            var created = _service.AdicionarOuAtualizaProduto(Produto, null);
            return CreatedAtAction(nameof(GetById), new { id = created.Value.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update( ProdutoBO Produto, int id)
        {
            _service.AdicionarOuAtualizaProduto(Produto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _service.RemoverProduto(id);
            return NoContent();
        }
    }
}

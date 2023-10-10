using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Projeto_Final.Model;
using Projeto_Final.Service;

namespace Projeto_Final.Controller
{
    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;

        public ProdutoController(
            IProdutoService produtoService,
            IValidator<Produto> produtoValidator)
        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var resposta = await _produtoService.GetById(id);

            if (resposta is null)
            {
                return NotFound();
            }

            return Ok(resposta);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _produtoService.GetByNome(nome));
        }

        [HttpGet("fabricante/{fabricante}")]
        public async Task<ActionResult> GetByFabricante(string fabricante)
        {
            return Ok(await _produtoService.GetByNome(fabricante));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Categoria não encontrada!");

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.Id == 0)
                return BadRequest("Id do Produto é inválido!");

            var validarProduto = await _produtoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _produtoService.Update(produto);

            if (Resposta is null)
                return NotFound("Produto e/ou Categoria não encontrados!");

            return Ok(Resposta);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            {
                var BuscaProduto = await _produtoService.GetById(id);

                if (BuscaProduto is null)
                    return NotFound("Produto não encontrado!");

                await _produtoService.Delete(BuscaProduto);

                return NoContent();

            }
        }
    }
}


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
        public async Task <ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }
    }
}

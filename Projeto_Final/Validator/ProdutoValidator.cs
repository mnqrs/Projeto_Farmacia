using FluentValidation;
using Projeto_Final.Model;

namespace Projeto_Final.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(p => p.Fabricante)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(p => p.Descricao)
                .MaximumLength (1000);

            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.Foto)
                .NotEmpty();
        }
    }
}

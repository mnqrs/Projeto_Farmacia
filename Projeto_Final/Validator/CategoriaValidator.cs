using FluentValidation;
using Projeto_Final.Model;

namespace Projeto_Final.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() {

            RuleFor(c => c.Tipo)
                    .NotEmpty()
                    .MinimumLength(3);

            RuleFor(c => c.Descricao)
                .NotEmpty();        
        }
    }
}

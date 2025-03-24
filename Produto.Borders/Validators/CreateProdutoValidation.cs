using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Produto.Borders.Dtos;

namespace Produto.Borders.Validators
{
  public class CreateProdutoValidation : AbstractValidator<ProdutoDto>
  {
    public CreateProdutoValidation()
    {
      RuleFor(a => a.Descricao)
        .NotEmpty().WithMessage("Descrição é obrigatória")
        .MinimumLength(5).When(a => a.Descricao.IsNullOrEmpty()).WithMessage("Descrição deve ter no mínimo 5 caracteres")
        .MaximumLength(200).WithMessage("Descrição deve ter no máximo 200 caracteres");

      RuleFor(a => a.Preco)
        .NotEmpty().WithMessage("Preço é obrigatório");
    }

  }
}

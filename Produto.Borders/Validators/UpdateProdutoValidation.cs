using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Produto.Borders.Dtos;

namespace Produto.Borders.Validators
{
  public class UpdateProdutoValidation : AbstractValidator<ProdutoDto>
  {
    public UpdateProdutoValidation()
    {
      RuleFor(a => a.Id)
        .NotEmpty().WithMessage("Id é obrigatório");

      RuleFor(a => a.Nome)
        .NotEmpty().WithMessage("Nome é obrigatório")
        .MinimumLength(5).When(a => a.Nome.IsNullOrEmpty()).WithMessage("Nome deve ter no mínimo 5 caracteres");

      RuleFor(a => a.Descricao)
        .NotEmpty().WithMessage("Descrição é obrigatória")
        .MinimumLength(5).When(a => a.Descricao.IsNullOrEmpty()).WithMessage("Descrição deve ter no mínimo 5 caracteres")
        .MaximumLength(200).WithMessage("Descrição deve ter no máximo 200 caracteres");

      RuleFor(a => a.Preco)
        .NotNull().WithMessage("Preço é obrigatório");
    }

  }
}

using FluentValidation;
using Produto.Borders.Dtos;
using Produto.Borders.Validators;

namespace Produto.Api.Configurations;

public static class ValidatorsConfig
{
  public static void AddCustomValidators(this IServiceCollection services)
  {
    //services.AddSingleton<IValidator<ProdutoDto>, CreateProdutoValidation>(); // NÃO FUNCIONA

    services.AddValidatorsFromAssemblyContaining<CreateProdutoValidation>(ServiceLifetime.Singleton)
            .AddValidatorsFromAssemblyContaining<UpdateProdutoValidation>(ServiceLifetime.Singleton);
  }
}


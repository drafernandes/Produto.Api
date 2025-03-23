using Produto.Borders.UseCases.ProdutoUseCase;
using Produto.UseCases.ProdutoUseCase;

namespace Produto.Api.Configurations;

public static class UseCasesConfig
{
  public static void AddUseCases(this IServiceCollection services) => services
    .AddScoped<IGetAllProdutosUseCase, GetAllProdutosUseCase>()
    .AddScoped<IGetProdutoByIdUseCase, GetProdutoByIdUseCase>()
    .AddScoped<ICreateProdutoUseCase, CreateProdutoUseCase>();
}

using Produto.Borders.Repositories;
using Produto.Repositories;

namespace Produto.Api.Configurations;

public static class RepositoriesConfig
{
  public static void AddRepositories(this IServiceCollection services) =>
    services.AddScoped<IProdutoRepository, ProdutoRepository>();

}
using Produto.Borders.MapperProfiles;

namespace Produto.Api.Configurations
{
  public static class MapperConfig
  {
    public static void AddMapperProfiles(this IServiceCollection services)
    {
      services.AddAutoMapper(opts =>
      {
        opts.AddProfile<ProdutoProfile>();
      });
    }
  }
}

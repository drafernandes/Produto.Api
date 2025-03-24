using Microsoft.EntityFrameworkCore;
using Produto.Borders.Data;

namespace Produto.Api.Configurations
{
  public static class DatabaseConfig
  {
    public static void AddDatabase(this IServiceCollection services, ConfigurationManager configuration)
    {
      services.AddDbContext<ProductContext>(options => options.UseSqlServer(configuration.GetConnectionString("")));
    }

  }
}

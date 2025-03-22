
using Produto.Api.Configurations;
using Produto.Api.Middlewares;

namespace Produto
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      builder.Services.AddRepositories();
      builder.Services.AddUseCases();
      builder.Services.AddMapperProfiles();

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.UseMiddleware<ErrorHandlingMiddlewares>();

      app.MapControllers();

      app.Run();
    }
  }
}


using FluentValidation;
using Produto.Api.Configurations;
using Produto.Api.Middlewares;
using Produto.Borders.Validators;

namespace Produto
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddCustomValidators();

      builder.Services.AddControllers();
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      builder.Services.AddRepositories();
      builder.Services.AddUseCases();
      builder.Services.AddMapperProfiles();

      //builder.Services.AddDatabase(builder.Configuration);

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

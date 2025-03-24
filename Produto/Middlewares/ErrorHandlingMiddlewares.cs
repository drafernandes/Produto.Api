using Produto.Borders.Exceptions;
using Produto.Shared.Errors;
using System.Net;
using System.Text.Json;
using FluentValidation;

namespace Produto.Api.Middlewares
{
  public class ErrorHandlingMiddlewares
  {
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddlewares(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ErrorHandlingMiddlewares> logger)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex, logger);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlingMiddlewares> logger)
    {
      var (code, errorMessage, errors) = exception switch
      {
        ArgumentException e => (HttpStatusCode.BadRequest, e.Message, new[] { new ErrosMessage(ErrosCode.BadRequest, e.Message) }),
        KeyNotFoundException e => (HttpStatusCode.NotFound, e.Message, new[] { new ErrosMessage(ErrosCode.BadRequest, e.Message) }),
        UseCaseException e => (HttpStatusCode.BadRequest, e.Message,  e.error.ToArray() ),
        ValidationException e => (HttpStatusCode.BadRequest, "Validations errors",  e.Errors?.Select(error=> new ErrosMessage(error.ErrorCode, error.ErrorMessage))),
        _ => (HttpStatusCode.InternalServerError, exception.Message, new[] { new ErrosMessage(ErrosCode.BadRequest, "Um erro interno ocorreu.") })
      };

      if (errorMessage != null)
      {
        logger.LogError(exception, errorMessage);
      }

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;

      return context.Response.WriteAsync(JsonSerializer.Serialize(errors, new JsonSerializerOptions()));
    }

  }
}

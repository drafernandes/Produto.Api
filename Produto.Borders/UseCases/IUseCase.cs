namespace Produto.Borders.UseCases
{
  public interface IUseCase<TRequest, TResponse>
  {
    Task<TResponse> ExecuteAsync(TRequest request);
  }

  public interface IUseCaseOnlyResponse<TResponse>
  {
    Task<TResponse> ExecuteAsync();
  }

  public interface IUseCaseOnlyRequest<TRequest>
  {
    Task<TRequest> ExecuteAsync(TRequest request);
  }
}

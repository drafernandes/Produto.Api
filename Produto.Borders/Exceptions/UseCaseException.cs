using Produto.Shared.Errors;

namespace Produto.Borders.Exceptions
{
  public class UseCaseException : Exception
  {
    public ErrosMessage error { get; set; }

    public UseCaseException(string message) : base(message)
    {
      error = new ErrosMessage("0", message);
    }

    public UseCaseException(ErrosMessage message) : base(message.Message)
    {
      error = message;
    }
  }
}

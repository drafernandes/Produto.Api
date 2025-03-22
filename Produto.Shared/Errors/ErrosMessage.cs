namespace Produto.Shared.Errors
{
  public class ErrosMessage
  {
    public ErrosMessage(string code, string message)
    {
      Code = code;
      Message = message;  
    }

    public string Code { get; set; }
    public string Message { get; set; } = string.Empty;
  }
}

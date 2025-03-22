namespace Produto.Api.Configurations
{
  public class AppConfig
  {
    public Database Database { get; set; } = new Database();
  }

  public class Database
  {
    public string ConnectionString { get; set; } = default!;
  }
}

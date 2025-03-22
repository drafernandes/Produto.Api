namespace Produto.Borders.Entities
{
  public class Produto
  {
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
  }
}

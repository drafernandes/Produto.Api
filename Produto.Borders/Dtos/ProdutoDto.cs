namespace Produto.Borders.Dtos
{
  public class ProdutoDto
  {
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
  }
}

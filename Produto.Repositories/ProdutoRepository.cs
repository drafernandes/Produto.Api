using Produto.Borders.Repositories;

namespace Produto.Repositories
{
  public class ProdutoRepository : IProdutoRepository
  {
    private IEnumerable<Borders.Entities.Produto> _produtos = new List<Borders.Entities.Produto>
    {
      new Borders.Entities.Produto
      {
        Id = 1,
        Nome = "Produto 1",
        Preco = 10.0M,
        Descricao = "Descrição do Produto 1",
        Estoque = 20
      },
      new Borders.Entities.Produto
      {
        Id = 2,
        Nome = "Produto 2",
        Preco = 20.0M,
        Descricao = "Descrição do Produto 2",
        Estoque = 5
      },
      new Borders.Entities.Produto
      {
        Id = 3,
        Nome = "Produto 3",
        Preco = 30.0M,
        Descricao = "Descrição do Produto 3",
        Estoque = 10
      }
    };

    public Task<Borders.Entities.Produto> CreateAsync(Borders.Entities.Produto produto)
    {
      _produtos = _produtos.Append(produto);
      return Task.FromResult(produto);
    }

    public Task DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Borders.Entities.Produto>> GetAllAsync()
    {
      return Task.FromResult(_produtos);
    }

    public Task<Borders.Entities.Produto?> GetByIdAsync(int id)
    {
      return Task.FromResult(_produtos.FirstOrDefault(p => p.Id == id));
    }

    public Task<Borders.Entities.Produto> UpdateAsync(Borders.Entities.Produto produto)
    {
      throw new NotImplementedException();
    }
  }
}

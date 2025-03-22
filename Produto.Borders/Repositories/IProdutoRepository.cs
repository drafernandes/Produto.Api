namespace Produto.Borders.Repositories;

public interface IProdutoRepository
{
  Task<IEnumerable<Entities.Produto>> GetAllAsync();
  Task<Entities.Produto?> GetByIdAsync(int id);
  Task<Entities.Produto> CreateAsync(Entities.Produto produto);
  Task<Entities.Produto> UpdateAsync(Entities.Produto produto);
  Task DeleteAsync(int id);
}


using Produto.Borders.Dtos;

namespace Produto.Borders.UseCases.ProdutoUseCase;

public interface IGetAllProdutosUseCase : IUseCaseOnlyResponse<IEnumerable<ProdutoDto>>
{
}
using AutoMapper;
using Produto.Borders.Dtos;
using Produto.Borders.Repositories;
using Produto.Borders.UseCases.ProdutoUseCase;

namespace Produto.UseCases.ProdutoUseCase
{
  public class GetAllProdutosUseCase : IGetAllProdutosUseCase
  {
    private readonly IProdutoRepository produtoRepository;
    private readonly IMapper mapper;

    public GetAllProdutosUseCase(IProdutoRepository produtoRepository, IMapper mapper)
    {
      this.produtoRepository = produtoRepository;
      this.mapper = mapper;
    }
    public async Task<IEnumerable<ProdutoDto>> ExecuteAsync()
    {
      var result = await produtoRepository.GetAllAsync();

      if (result is null || !result.Any())
        return Enumerable.Empty<ProdutoDto>();

      return mapper.Map<IEnumerable<ProdutoDto>>(result);
    }
  }
}

using AutoMapper;
using Produto.Borders.Dtos;
using Produto.Borders.Exceptions;
using Produto.Borders.Repositories;
using Produto.Borders.UseCases.ProdutoUseCase;
using Produto.Shared.Errors;

namespace Produto.UseCases.ProdutoUseCase
{
  public class GetProdutoByIdUseCase : IGetProdutoByIdUseCase
  {
    private readonly IProdutoRepository produtoRepository;
    private readonly IMapper mapper;

    public GetProdutoByIdUseCase(IProdutoRepository produtoRepository, IMapper mapper)
    {
      this.produtoRepository = produtoRepository;
      this.mapper = mapper;
    }

    public async Task<ProdutoDto> ExecuteAsync(int request)
    {
      var produto = await produtoRepository.GetByIdAsync(request);

      if (produto == null)
      {
        throw new UseCaseException(CustomErrosMessage.ProdutoNaoEncontrato);
      }

      return mapper.Map<ProdutoDto>(produto);
    }
  }
}

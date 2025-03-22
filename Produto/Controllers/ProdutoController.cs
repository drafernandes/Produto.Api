using Microsoft.AspNetCore.Mvc;
using Produto.Borders.UseCases.ProdutoUseCase;

namespace Produto.Controllers
{
  [ApiController]
  [Route("api/produto")]
  public class ProdutoController : ControllerBase
  {
    private readonly IGetAllProdutosUseCase _getAllProdutosUseCase;
    private readonly IGetProdutoByIdUseCase _getProdutoByIdUseCase;

    public ProdutoController(IGetAllProdutosUseCase getAllProdutosUseCase
                            , IGetProdutoByIdUseCase getProdutoByIdUseCase)
    {
      _getAllProdutosUseCase = getAllProdutosUseCase;
      _getProdutoByIdUseCase = getProdutoByIdUseCase;
    }

    public IGetProdutoByIdUseCase GetProdutoByIdUseCase { get; }

    [HttpGet()]
    public async Task<IResult> GetAllAsync()
    {
      var result = await _getAllProdutosUseCase.ExecuteAsync();
      return Results.Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetByIdAsync([FromRoute] int id)
    {
      var result = await _getProdutoByIdUseCase.ExecuteAsync(id);
      return Results.Ok(result);
    }
  }
}

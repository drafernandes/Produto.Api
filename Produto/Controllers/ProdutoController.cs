using Microsoft.AspNetCore.Mvc;
using Produto.Borders.Dtos;
using Produto.Borders.UseCases.ProdutoUseCase;

namespace Produto.Controllers
{
  [ApiController]
  [Route("api/produto")]
  public class ProdutoController : ControllerBase
  {
    private readonly IGetAllProdutosUseCase _getAllProdutosUseCase;
    private readonly IGetProdutoByIdUseCase _getProdutoByIdUseCase;
    private readonly ICreateProdutoUseCase _createProdutoUseCase;

    public ProdutoController(IGetAllProdutosUseCase getAllProdutosUseCase
                            , IGetProdutoByIdUseCase getProdutoByIdUseCase
                            , ICreateProdutoUseCase createProdutoUseCase)
    {
      _getAllProdutosUseCase = getAllProdutosUseCase;
      _getProdutoByIdUseCase = getProdutoByIdUseCase;
      _createProdutoUseCase = createProdutoUseCase;
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

    [HttpPost()]
    public async Task<IResult> CreateAsync([FromBody] ProdutoDto request)
    {
      var result = await _createProdutoUseCase.ExecuteAsync(request);
      return Results.Ok(result);
    }
  }
}

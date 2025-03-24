using AutoMapper;
using Produto.Borders.Dtos;
using Produto.Borders.Exceptions;
using Produto.Borders.Repositories;
using Produto.Borders.UseCases.ProdutoUseCase;
using Produto.Borders.Validators;
using Produto.Shared.Errors;

namespace Produto.UseCases.ProdutoUseCase
{
  public class CreateProdutoUseCase : ICreateProdutoUseCase
  {
    private readonly IProdutoRepository produtoRepository;
    private readonly IMapper mapper;
    private readonly CreateProdutoValidation createProdutoValidation;

    public CreateProdutoUseCase(IProdutoRepository produtoRepository, IMapper mapper, CreateProdutoValidation createProdutoValidation)
    {
      this.produtoRepository = produtoRepository;
      this.mapper = mapper;
      this.createProdutoValidation = createProdutoValidation;
    }

    public async Task<ProdutoDto> ExecuteAsync(ProdutoDto request)
    {
      if (request == null)
        throw new UseCaseException(CustomErrosMessage.ObjectProdutoNotFilled);

      var errors = createProdutoValidation.Validate(request);

      if (!errors.IsValid)
      {
        List<ErrosMessage> exceptions = new List<ErrosMessage>();

        foreach (var error in errors.Errors)
          exceptions.Add(new ErrosMessage("1005" ,error.ErrorMessage));

        throw new UseCaseException(exceptions);
      }

      var produtoMapper = mapper.Map<Borders.Entities.Produto>(request);

      var result = await produtoRepository.CreateAsync(produtoMapper);

      if(result == null)
        throw new UseCaseException(CustomErrosMessage.ProdutoNaoCadastrado); 

      var produtoDto = mapper.Map<ProdutoDto>(result);

      return produtoDto;
    }
  }
}

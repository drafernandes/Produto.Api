using AutoMapper;
using Produto.Borders.Dtos;
using Produto.Borders.Exceptions;
using Produto.Borders.Repositories;
using Produto.Borders.UseCases.ProdutoUseCase;
using Produto.Borders.Validators;
using Produto.Shared.Errors;

namespace Produto.UseCases.ProdutoUseCase
{
  public class UpdateProdutoUseCase : IUpdateProdutoUseCase
  {
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private readonly UpdateProdutoValidation _updateProdutoValidation;

    public UpdateProdutoUseCase(IProdutoRepository produtoRepository
                               ,IMapper mapper
                               ,UpdateProdutoValidation  validationRules)
    {
      this._produtoRepository = produtoRepository;
      this._mapper = mapper;
      this._updateProdutoValidation = validationRules;
    }

    public async Task<ProdutoDto> ExecuteAsync(ProdutoDto request)
    {
      if(request == null)
        throw new UseCaseException(CustomErrosMessage.ObjectProdutoNotFilled);

      var errors = _updateProdutoValidation.Validate(request);

      if (!errors.IsValid)
      {
        List<ErrosMessage> exceptions = new List<ErrosMessage>();

        foreach (var error in errors.Errors)
          exceptions.Add(new ErrosMessage("1005", error.ErrorMessage));

        throw new UseCaseException(exceptions);
      }

      var existprod = await _produtoRepository.GetByIdAsync(request.Id);

      if(existprod == null)
        throw new UseCaseException(CustomErrosMessage.ProdutoNaoEncontrato);

      var product = _mapper.Map<Borders.Entities.Produto>(request);

      var result = await _produtoRepository.UpdateAsync(product);

      if (result == null)
        throw new UseCaseException(CustomErrosMessage.ProdutoNaoCadastrado);

      var productDto = _mapper.Map<ProdutoDto>(result);

      return productDto;
    }
  }
}

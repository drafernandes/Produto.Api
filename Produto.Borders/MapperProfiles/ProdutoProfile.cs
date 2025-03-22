using AutoMapper;

namespace Produto.Borders.MapperProfiles;

public class ProdutoProfile : Profile
{
  public ProdutoProfile()
  {
    CreateMap<Entities.Produto, Dtos.ProdutoDto>().ReverseMap();
  }
}
namespace Produto.Shared.Errors
{
  public static class ErrosCode
  {
    public const string InternalServerError = "0000";
    public const string NotFound = "0001";
    public const string BadRequest = "0002";

    public const string ProdutoNaoEncontrado = "1000";
    public const string ProdutoJaCadastrado = "1001";
    public const string ProdutoNaoCadastrado = "1002";
    public const string ObjectProdutoNotFilled = "1003";
  }
}

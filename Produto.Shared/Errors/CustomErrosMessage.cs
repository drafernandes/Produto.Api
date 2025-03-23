namespace Produto.Shared.Errors
{
  public static class CustomErrosMessage
  {
    public static ErrosMessage ProdutoNaoEncontrato = new ErrosMessage(ErrosCode.ProdutoNaoEncontrado, "Produto não encontrado");
    public static ErrosMessage ObjectProdutoNotFilled = new ErrosMessage(ErrosCode.ObjectProdutoNotFilled, "Verifique os dados preenchidos");
    public static ErrosMessage ProdutoNaoCadastrado = new ErrosMessage(ErrosCode.ObjectProdutoNotFilled, "Produto não cadastrado, gentileza tentar novamente.");
  }
}

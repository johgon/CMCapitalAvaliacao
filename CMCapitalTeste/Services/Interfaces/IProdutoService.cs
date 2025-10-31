using CMCapitalTesteController.Models;

namespace CMCapitalAvaliacao.Services.Interfaces
{
	public interface IProdutoService
	{
		Retorno<IEnumerable<ProdutoBO>> ListarProdutos();
		Retorno<ProdutoBO?> BuscaProduto(int id);
		Retorno<ProdutoBO> AdicionarOuAtualizaProduto(ProdutoBO produto,int? id);
		Retorno<bool> RemoverProduto(int id);
	}
}
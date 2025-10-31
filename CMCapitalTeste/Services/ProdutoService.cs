using CMCapitalAvaliacao.Repositories.Interfaces;
using CMCapitalAvaliacao.Services.Interfaces;
using CMCapitalTesteController.Models;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace CMCapitalAvaliacao.Services
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public Retorno<IEnumerable<ProdutoBO>> ListarProdutos()
        {
            return _repo.GetAll();
        }
        public Retorno<ProdutoBO> BuscaProduto(int id)
        {
            return _repo.GetById(id);
        }
        public Retorno<ProdutoBO> AdicionarOuAtualizaProduto(ProdutoBO produto, int? id)
        {
            Retorno<ProdutoBO> ret = new Retorno<ProdutoBO>();
            if (String.IsNullOrEmpty(produto.Nome)){
                ret.Value = null;
                ret.sucesso = false;
                ret.mensagem = "Nome vazio";
                return ret;
            }
            if (produto.Quantidade<0)
            {
                ret.Value = null;
                ret.sucesso = false;
                ret.mensagem = "Quantidade inválida";
                return ret;
            }
            if (produto.Preco < 0)
            {
                ret.Value = null;
                ret.sucesso = false;
                ret.mensagem = "Preço não pode ser negatívo";
                return ret;
            }
            return _repo.AddOrUpdate(produto, id);
        }
        public Retorno<bool> RemoverProduto(int id)
        {
            return _repo.Delete(id);
        }
    }
}

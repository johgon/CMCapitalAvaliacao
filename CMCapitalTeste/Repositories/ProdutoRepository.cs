using CMCapitalAvaliacao.Data;
using CMCapitalAvaliacao.Repositories.Interfaces;
using CMCapitalTesteController.Models;

namespace CMCapitalAvaliacao.Repositories
{
    public class ProdutoRepository : Repository<ProdutoBO>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }
    }
}

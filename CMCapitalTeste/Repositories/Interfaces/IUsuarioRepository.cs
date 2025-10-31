using CMCapitalAvaliacao.Models;
using CMCapitalTesteController.Models;

namespace CMCapitalAvaliacao.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<UsuarioBO>
    {
        UsuarioBO? GetByUsername(string username);
    }
}

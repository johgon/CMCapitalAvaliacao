using CMCapitalAvaliacao.Data;
using CMCapitalAvaliacao.Models;
using CMCapitalAvaliacao.Repositories.Interfaces;
using CMCapitalTesteController.Models;

namespace CMCapitalAvaliacao.Repositories
{
    public class UsuarioRepository : Repository<UsuarioBO>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }
        public UsuarioBO? GetByUsername(string nome)
        {
            return _context.Usuario.FirstOrDefault(u => u.Username == nome);
        }
    }
}

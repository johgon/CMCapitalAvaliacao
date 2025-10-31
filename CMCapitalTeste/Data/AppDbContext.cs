using CMCapitalAvaliacao;
using CMCapitalAvaliacao.Models;
using CMCapitalTesteController.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CMCapitalAvaliacao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) { }
        public DbSet<ProdutoBO> Produtos => Set<ProdutoBO>();
        public DbSet<UsuarioBO> Usuario => Set<UsuarioBO>();
        public DbSet<VendaBO> Venda => Set<VendaBO>();
        public DbSet<ClietesBO> Cliente => Set<ClietesBO>();
    }
}

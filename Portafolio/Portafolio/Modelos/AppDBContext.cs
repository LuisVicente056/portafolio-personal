using Microsoft.EntityFrameworkCore;

namespace Portafolio.Modelos  // ← debe decir Portafolio, no otro nombre
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
    }
}
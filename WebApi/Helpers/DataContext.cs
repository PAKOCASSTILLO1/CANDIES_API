using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<RolPagina> RolPagina { get; set; }
    }
}
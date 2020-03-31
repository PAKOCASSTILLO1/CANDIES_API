using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RolePage> RolePage { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace ProvaApi.Db
{
    public class Context : DbContext
    {
        public Context(DbContextOptions option) : base(option) { }

        public DbSet<DDato> dato { get; set; }
        public DbSet<DPersona> persona { get; set; }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ContatoContextDb : DbContext
    {
        public ContatoContextDb(DbContextOptions<ContatoContextDb> options) :base(options)
        {         
        }

        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContatoContextDb).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

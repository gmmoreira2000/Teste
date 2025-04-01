using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

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

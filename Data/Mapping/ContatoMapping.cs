using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder) 
        { 
            builder.HasKey(x => x.Id);
            
            builder.Property(x=> x.Id)
                .IsRequired()
                .HasColumnType("varchar(80)");
            
            builder.Property(x => x.DataNascimento)
                .IsRequired().
                HasColumnType("datetime");
            
            builder.Property(x => x.Sexo)
                .IsRequired()
                .HasColumnType("char(1)");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Contato");
        }
    }
}

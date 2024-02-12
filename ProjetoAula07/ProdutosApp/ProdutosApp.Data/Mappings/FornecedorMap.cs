using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            //nome da tabela
            builder.ToTable("FORNECEDOR");

            //Campo chave primária
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.RazaoSocial)
                .HasColumnName("RAZAO SOCIAL")
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.Cnpj)
            .HasColumnName("CNPJ")
            .HasMaxLength(20)
            .IsRequired();

            //builder.HasIndex(c => c.RazaoSocial)
            //    .IsUnique();
            
            builder.HasIndex(c => c.Cnpj)
                .IsUnique();
        }
    }
}

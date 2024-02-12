using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //nome da tabela
            builder.ToTable("PRODUTO");

            //Chave primária
            builder.HasKey(c => c.Id);

            //mapeamento do campo 'Id'
            builder.Property(c => c.Id)
                .HasColumnName("ID");

            //mapeamento do campo 'Nome'
            builder.Property(c => c.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();

            //mapeamento do campo 'Preco'
            builder.Property(c => c.Preco)
             .HasColumnName("PRECO")
             .HasColumnType("DECIMAL(10,2)")
             .IsRequired();

            //mapeamento do campo 'Quantidade'
            builder.Property(c => c.Quantidade)
             .HasColumnName("QUANTIDADE")
             .IsRequired();

            //mapeamento do campo 'CategoriaId'
            builder.Property(c => c.CategoriaId)
             .HasColumnName("CATEGORIA_ID")
             .IsRequired();

            //mapeamento do campo 'FornecedorId'
            builder.Property(c => c.FornecedorId)
            .HasColumnName("FORNECEDOR_ID")
            .IsRequired();

            //mapeamento do relacionamento Produto com Categoria (1pN)
            builder.HasOne(c => c.Categoria) // Produto TEM 1 Categoria
                .WithMany(p => p.Produtos) // Categoria TEM MUITOS Produto
                .HasForeignKey(p => p.CategoriaId) // Chave Estrangeira
                .OnDelete(DeleteBehavior.NoAction); // Não fazer delete em cascata

            //mapeamento do relacionamento Produto com Fornecedor
            builder.HasOne(c => c.Fornecedor) // Produto TEM 1 Fornecedor
                .WithMany(p => p.Produtos) // Fornecedor TEM MUITOS Produto
                .HasForeignKey(p => p.FornecedorId) // Chave Estrangeira
                .OnDelete(DeleteBehavior.NoAction); // Não fazer delete em cascata
        }
    }
}

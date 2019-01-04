using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.EntityConfig
{
    public class ConfigProduto : EntityTypeConfiguration<Produto>
    {
        public ConfigProduto()
        {
            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.CodigoProduto)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CodigoProduto") { IsUnique = true }));

            Property(p => p.Quantidade)
                .IsRequired();

            Property(p => p.Fornecedor)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            Property(p => p.ValorUnitario)
                .IsRequired();

            Property(p => p.Excluido)
                .IsRequired();

            Property(p => p.DataValidade)
                .IsRequired();

            Property(p => p.DataCadastro)
                .IsRequired();


            //relacionamento
            HasRequired(c => c.Categorias)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.CategoriaId);

            HasRequired(o => o.Pedidos)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.PedidoId);

            ToTable("Produtos");
        }
    }
}

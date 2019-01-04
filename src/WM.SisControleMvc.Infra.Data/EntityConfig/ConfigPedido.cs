using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.EntityConfig
{
    public class ConfigPedido : EntityTypeConfiguration<Pedido>
    {
        public ConfigPedido()
        {
            HasKey(p => p.Id);

            Property(p => p.CodigoPedido)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CodigoPedido") { IsUnique = true }));

            Property(p => p.DataPedido)
                .IsRequired();

            Property(p => p.Situacao)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.ValorPedido)
              .IsRequired();

            Property(p => p.Ativo)
              .IsRequired();

            Property(p => p.Excluido)
              .IsRequired();

            ToTable("Pedidos");
        }
    }
}

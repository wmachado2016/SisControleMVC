using System.Data.Entity.ModelConfiguration;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.EntityConfig
{
    public class ConfigCategoria : EntityTypeConfiguration<Categoria>
    {
        public ConfigCategoria()
        {
            HasKey(c => c.Id);

            Property(c => c.NomeCategoria )
                .IsRequired()
                .HasMaxLength(30);

            Property(C => C.Ativo)
              .IsRequired();

            Property(C => C.Excluido)
             .IsRequired();

            ToTable("Categorias");

        }
    }
}

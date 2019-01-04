using System.Data.Entity.ModelConfiguration;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.EntityConfig
{
    public class ConfigTelefone : EntityTypeConfiguration<Telefone>
    {
        public ConfigTelefone()
        {
            HasKey(t => t.Id);

            Property(t => t.NumeroTele)
                    .IsRequired();

            Property(t => t.TipoTelefone)
                    .IsRequired()
                    .HasMaxLength(10);

            Property(t => t.Ativo)
             .IsRequired();

            Property(t => t.Excluido)
             .IsRequired();

            //relacionamento
            HasRequired(u => u.Usuario)
                .WithMany(t => t.Telefones)
                .HasForeignKey(u => u.UsuarioId);

            ToTable("Telefones");

        }
    }
}

using System.Data.Entity.ModelConfiguration;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.EntityConfig
{
    public class ConfigEndereco : EntityTypeConfiguration<Endereco>
    {
        public ConfigEndereco()
        {
            //HasKey(u => new { u.ClienteId, u.Id });
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(150);
            Property(u => u.Numero)
                    .IsRequired()
                    .HasMaxLength(20);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cidade)
                 .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Estado)
                    .IsRequired();

            Property(e => e.CEP)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();

            Property(e => e.Complemento)
                    .IsRequired();

            Property(e => e.Ativo)
             .IsRequired();

            Property(e => e.Excluido)
             .IsRequired();

            //relacionamento
            HasRequired(e => e.Usuario)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(e => e.UsuarioId);

            ToTable("Enderecos");

            //ONE TO ONE OR ZERO - UM PRA UM OU NENHUM
            //ONE TO ONE -
            //ONE TO MANY OR ZERO - UM PRA MUITOS OU NENHUM
            //MANY TO MANY

        }

    }
}

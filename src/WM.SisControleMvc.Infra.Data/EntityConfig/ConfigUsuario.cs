using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.EntityConfig
{
    /// <summary>
    /// Fluente Api
    /// </summary>
    public class ConfigUsuario : EntityTypeConfiguration<Usuario>
    {       
        public ConfigUsuario()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CNPJ") { IsUnique = true }));

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.TipoUsuario)
                .IsRequired();

            Property(c => c.Excluido)
                .IsRequired();

            ToTable("Usuarios");


        }
    }
}

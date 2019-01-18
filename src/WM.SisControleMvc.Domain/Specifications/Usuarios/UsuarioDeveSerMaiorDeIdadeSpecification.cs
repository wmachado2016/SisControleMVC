using DomainValidation.Interfaces.Specification;
using System;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Specifications.Usuarios
{
    public class UsuarioDeveSerMaiorDeIdadeSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return DateTime.Now.Year - usuario.DataNascimento.Year >= 18;
        }
    }
}

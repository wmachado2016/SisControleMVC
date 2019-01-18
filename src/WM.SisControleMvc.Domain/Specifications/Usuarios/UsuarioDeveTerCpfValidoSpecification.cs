using DomainValidation.Interfaces.Specification;
using System;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Domain.ValueObjects;

namespace WM.SisControleMvc.Domain.Specifications.Usuarios
{
    public class UsuarioDeveTerCpfValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario _usuario)
        {
            return CPF.Validar(_usuario.CPF);
        }
    }
}

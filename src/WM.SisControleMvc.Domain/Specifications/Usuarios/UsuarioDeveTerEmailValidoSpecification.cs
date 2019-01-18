using DomainValidation.Interfaces.Specification;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Domain.ValueObjects;

namespace WM.SisControleMvc.Domain.Specifications.Usuarios
{
    public class UsuarioDeveTerEmailValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario _usuario)
        {
            return Email.Validate(_usuario.Email);
        }
    }
}

using DomainValidation.Interfaces.Specification;
using System.Linq;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Specifications.Usuarios
{
    class UsuarioDeveTerUmEnderecoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return usuario.Enderecos != null && usuario.Enderecos.Any();
        }
    }
}

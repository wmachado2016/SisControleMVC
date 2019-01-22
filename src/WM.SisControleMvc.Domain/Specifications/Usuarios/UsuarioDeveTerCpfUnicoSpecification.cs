using DomainValidation.Interfaces.Specification;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Specifications.Usuarios
{
    public class UsuarioDeveTerCpfUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDeveTerCpfUnicoSpecification(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepository.ObterPorCpf(usuario.CPF) == null;
        }
    }
}

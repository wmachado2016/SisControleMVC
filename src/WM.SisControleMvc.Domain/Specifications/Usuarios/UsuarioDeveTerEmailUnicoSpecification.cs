using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Specifications.Usuarios
{
    class UsuarioDeveTerEmailUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioDeveTerEmailUnicoSpecification(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepository.ObterPorEmail(usuario.Email) == null;
        }
    }
}

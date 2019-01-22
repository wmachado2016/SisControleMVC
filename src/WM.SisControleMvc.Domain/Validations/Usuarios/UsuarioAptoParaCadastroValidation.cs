using DomainValidation.Validation;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Domain.Specifications.Usuarios;

namespace WM.SisControleMvc.Domain.DomainValidation.Validations.Usuarios
{
    public class UsuarioAptoParaCadastroValidation : Validator<Usuario>
    {
        public UsuarioAptoParaCadastroValidation(IUsuarioRepository usuarioRepository)
        {
            var cpfDuplicado = new UsuarioDeveTerCpfUnicoSpecification(usuarioRepository);
            var emailDuplicado = new UsuarioDeveTerEmailUnicoSpecification(usuarioRepository);
            var UsuarioEndereco = new UsuarioDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Usuario>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Usuario>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
            base.Add("UsuarioEndereco", new Rule<Usuario>(UsuarioEndereco, "Usuario não informou endereço"));
        }
    }
}

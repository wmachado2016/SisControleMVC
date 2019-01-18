using DomainValidation.Validation;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Domain.Specifications.Usuarios;

namespace WM.SisControleMvc.Domain.Validations.Usuarios
{
    public class UsuarioEstaConsistenteValidation : Validator<Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var CPFUsuario = new UsuarioDeveTerCpfValidoSpecification();
            var UsuarioEmail = new UsuarioDeveTerEmailValidoSpecification();
            var UsuarioMaioridade = new UsuarioDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFUsuario", new Rule<Usuario>(CPFUsuario, "Usuario informou um CPF inválido."));
            base.Add("UsuarioEmail", new Rule<Usuario>(UsuarioEmail, "Usuario informou um e-mail inválido."));
            base.Add("UsuarioMaioridade", new Rule<Usuario>(UsuarioMaioridade, "Usuario não tem maioridade para cadastro."));
        }
        
    }
}

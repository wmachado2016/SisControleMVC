using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.DomainValidation.Validations.Usuarios
{
    public class UsuarioAptoParaCadastroValidation : Validator<Usuario>
    {
        public UsuarioAptoParaCadastroValidation()
        {
            var cpfDuplicado = new UsuarioDevePossuirCPFUnicoSpecification(UsuarioRepository);
            var emailDuplicado = new UsuarioDevePossuirEmailUnicoSpecification(UsuarioRepository);
            var UsuarioEndereco = new UsuarioDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Usuario>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Usuario>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
            base.Add("UsuarioEndereco", new Rule<Usuario>(UsuarioEndereco, "Usuario não informou endereço"));
        }
    }
}

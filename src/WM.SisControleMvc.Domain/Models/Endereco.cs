using System;

namespace WM.SisControleMvc.Domain.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }
        public Guid UsuarioId { get; set; }


        // Propriedade de Navegação do EF
        public virtual Usuario Usuario { get; set; }

        public void DefinirComoExcluido()
        {
            Ativo = false;
            Excluido = true;
        }

        public void DefinirComoAtivo()
        {
            Ativo = true;
            Excluido = false;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}

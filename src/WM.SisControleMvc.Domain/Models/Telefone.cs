using System;

namespace WM.SisControleMvc.Domain.Models
{
    public class Telefone : Entity
    {
        public int NumeroTele { get; set; }
        public string TipoTelefone { get; set; }
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

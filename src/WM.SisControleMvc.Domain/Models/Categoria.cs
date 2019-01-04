using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.SisControleMvc.Domain.Models
{
    public class Categoria : Entity
    {
        public string NomeCategoria { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

        public virtual ICollection<Produto> Produtos { get; private set; }

        public Categoria(string nome, bool ativo)
        {
            NomeCategoria = nome;
            Ativo = ativo;
            Produtos = new List<Produto>();
        }
        public Categoria()
        {
            Produtos = new List<Produto>();
        }

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
            throw new NotImplementedException();
        }
    }
}

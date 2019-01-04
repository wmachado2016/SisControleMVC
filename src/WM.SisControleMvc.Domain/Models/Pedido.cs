using System;
using System.Collections.Generic;

namespace WM.SisControleMvc.Domain.Models
{
    public class Pedido : Entity
    {
        public string  CodigoPedido{get;private set; }
        public Guid UsuarioId { get; set; }
        public string Situacao { get; private set; }
        public DateTime DataPedido { get; private set; }
        public decimal ValorPedido { get; private set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

        public virtual ICollection<Produto> Produtos { get; private set; }        

        public Pedido(string codigo, decimal valor,string situacao )
        {
            CodigoPedido = codigo;
            ValorPedido = valor;
            Situacao = situacao;
            DataPedido = DateTime.Now;
            Produtos = new List<Produto>();
        }

        public Pedido() { }

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

using System;
using System.Collections.Generic;

namespace WM.SisControleMvc.Domain.Models
{
    public class Produto : Entity
    {
        public string CodigoProduto { get;private set; }
        public string Descricao { get; private set; }
        public decimal Quantidade { get; private set; }
        public string Fornecedor { get; set; }
        public decimal ValorUnitario { get; private set; }
        public string UnidadeMedida { get; set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }
        public Guid CategoriaId { get; set; }
        public Guid PedidoId { get; set; }

        // Propriedade de Navegação do EF
        public virtual Categoria Categorias { get; set; }
        public virtual Pedido Pedidos { get; set; }

        public Produto(string codigo,string descricao, decimal quantidade,decimal valorUnitario,string fornecedor, bool ativo)
        {
            CodigoProduto = codigo;
            DataCadastro = DateTime.Now;
            Descricao = descricao;
            Fornecedor = fornecedor;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Ativo = ativo;
        }
        public Produto() { }

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

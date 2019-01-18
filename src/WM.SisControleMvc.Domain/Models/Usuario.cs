using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using WM.SisControleMvc.Domain.Validations.Usuarios;

namespace WM.SisControleMvc.Domain.Models
{
    public class Usuario : Entity
    {

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

        public virtual ICollection<Endereco> Enderecos { get; private set; }
        public virtual ICollection<Telefone> Telefones { get; private set; }
       //public ValidationResult ValidationResult { get; set; }

        public Usuario(string nome, string email, string cpf, string cnpj, int tipoUsuario, DateTime dataNascimento, bool ativo)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            CNPJ = cnpj;
            TipoUsuario = tipoUsuario;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.Now;
            Ativo = ativo;
            Enderecos = new List<Endereco>();
            Telefones = new List<Telefone>();
        }

        public Usuario()
        {
            Enderecos = new List<Endereco>();
            Telefones = new List<Telefone>();
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

        public void TrocarEmail(string email)
        {
            //validar antes se o email esta valido
            Email = email;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco.EhValido())
                Enderecos.Add(endereco);
        }

        public override bool EhValido()
        {
            ValidationResult = new UsuarioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

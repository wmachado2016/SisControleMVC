using System;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario ObterPorId(Guid id);
        Usuario ObterPorCpf(string cpf);
        Usuario ObterPorEmail(string email);
        //Paged<Usuario> ObterTodos(string nome, int pageSize, int pageNumber);
        Usuario Atualizar(Usuario usuario);
        void Remover(Guid id);

        //Endereco AdicionarEndereco(Endereco endereco);
        //Endereco AtualizarEndereco(Endereco endereco);
        //Endereco ObterEnderecoPorId(Guid id);
        //void RemoverEndereco(Guid id);
    }
}

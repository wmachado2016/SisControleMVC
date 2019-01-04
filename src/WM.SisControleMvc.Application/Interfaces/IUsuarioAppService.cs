using System;
using System.Collections.Generic;
using WM.SisControleMvc.Application.ViewsModels;

namespace WM.SisControleMvc.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioEnderecoViewModel Adicionar(UsuarioEnderecoViewModel usuarioEnderecoViewModel);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        IEnumerable<UsuarioViewModel> ObterAtivos();
        IEnumerable<UsuarioViewModel> ObterArquivados();
        UsuarioViewModel ObterPorCpf(string cpf);
        UsuarioViewModel ObterPorEmail(string email);
        UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel);
        void Remover(Guid id);
    }
}

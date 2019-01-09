using AutoMapper;
using System;
using System.Collections.Generic;
using WM.SisControleMvc.Application.Interfaces;
using WM.SisControleMvc.Application.ViewsModels;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Infra.Data.Repository;

namespace WM.SisControleMvc.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public UsuarioEnderecoViewModel Adicionar(UsuarioEnderecoViewModel usuarioEnderecoViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioEnderecoViewModel.Usuario);
            var endereco = Mapper.Map<Endereco>(usuarioEnderecoViewModel.Endereco);

            usuario.DefinirComoAtivo();
            usuario.AdicionarEndereco(endereco);
            _usuarioRepository.Adicionar(usuario);

            return usuarioEnderecoViewModel;
        }
        
        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioViewModel);
            _usuarioRepository.Atualizar(usuario);

            return usuarioViewModel;
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
           return Mapper.Map<UsuarioViewModel>(_usuarioRepository.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.ObterTodos());
        }

        public IEnumerable<UsuarioViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.ObterAtivos());
        }

        public UsuarioViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.ObterPorCpf(cpf));
        }

        public UsuarioViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.ObterPorEmail(email));
        }

        public IEnumerable<UsuarioViewModel> ObterArquivados()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.ObterAtivos());
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }

        

       

        

        

        

        

       
    }
}

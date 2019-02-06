using AutoMapper;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using WM.SisControleMvc.Application.Interfaces;
using WM.SisControleMvc.Application.ViewsModels;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Infra.Data.UoW;

namespace WM.SisControleMvc.Application.Services
{
    public class UsuarioAppService : BaseService, IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService, IUnitofWork uow) : base(uow)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        public UsuarioEnderecoViewModel Adicionar(UsuarioEnderecoViewModel usuarioEnderecoViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioEnderecoViewModel.Usuario);
            var endereco = Mapper.Map<Endereco>(usuarioEnderecoViewModel.Endereco);

            usuario.DefinirComoAtivo();
            usuario.AdicionarEndereco(endereco);

            var usuarioRet = _usuarioService.Adicionar(usuario);

            AdicionarResultadoProcessamento(usuarioRet.ValidationResult);

            if (ValidacaoProcesso.IsValid) {

                if (!Commit()) {
                    //fazer alguma coisa, log, exception, add erro para retornar ao usuario
                    usuarioEnderecoViewModel.Usuario.ValidationResult.Add(new ValidationError("Ocorreu um erro no momento de salvar no banco de dados!"));
                }
            }

            usuarioEnderecoViewModel.Usuario = Mapper.Map<UsuarioViewModel>(usuarioRet);


            return usuarioEnderecoViewModel;
        }
        
        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioViewModel);
            _usuarioService.Atualizar(usuario);

            return usuarioViewModel;
        }

        public void Remover(Guid id)
        {
            _usuarioService.Remover(id);
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

using System;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido()) return usuario;

             return _usuarioRepository.Adicionar(usuario);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            if (!usuario.EhValido()) return usuario;

            return _usuarioRepository.Atualizar(usuario);
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }
           
        public Usuario ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}

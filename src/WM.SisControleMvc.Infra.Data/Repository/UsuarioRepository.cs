using System;
using System.Collections.Generic;
using System.Linq;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Infra.Data.Repository
{
    /// <summary>
    /// clase especializada para manipulaçao de informacoes especificas do usuario
    /// </summary>
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> ObterAtivos()
        {
            return Buscar(u => u.Ativo && !u.Excluido);
        }

        public Usuario ObterPorCpf(string cpf)
        {
            return Buscar(u => u.Ativo && !u.Excluido && u.CPF == cpf).FirstOrDefault();
        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(u => u.Ativo && !u.Excluido && u.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid Id)
        {
            //o metodo busca os dados do usuario define como excluido logicamente e depois salva os dados na base novamente
            var usuario = ObterPorId(Id);
            usuario.DefinirComoExcluido();

            Atualizar(usuario);
        }
    }
}

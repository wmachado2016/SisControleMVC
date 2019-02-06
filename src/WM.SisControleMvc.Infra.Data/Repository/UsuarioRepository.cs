using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Infra.Data.Context;

namespace WM.SisControleMvc.Infra.Data.Repository
{
    /// <summary>
    /// clase especializada para manipulaçao de informacoes especificas do usuario
    /// </summary>
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SisControleMvcContext context) : base(context) { }

        public IEnumerable<Usuario> ObterAtivos()
        {
            var sql = @"SELECT * FROM usuarios c " +
                      "WHERE c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Usuario>(sql);
        }

        public override Usuario ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM usuarios c " +
                      "LEFT JOIN Enderecos e " +
                      "ON c.Id = e.usuarioId " +
                      "WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Usuario, Endereco, Usuario>(sql,
                (c, e) =>
                {
                    c.AdicionarEndereco(e);
                    return c;

                }, new { uid = id }).FirstOrDefault();
        }

        public Usuario ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var usuario = ObterPorId(id);
            usuario.DefinirComoExcluido();

            Atualizar(usuario);
        }
    }
}

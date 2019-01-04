using System.Collections.Generic;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryRead<Usuario>, IRepositoryWrite<Usuario>
    {
        Usuario ObterPorCpf(string cpf);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterAtivos();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Interfaces
{
    /// <summary>
    /// Contratos que são implementados para que apenas sejam LIDO dados do repositorio
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid Id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodosPaginados(int s, int t);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity,bool>> predicate);

    }
}

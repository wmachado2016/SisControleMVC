using System;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Domain.Interfaces
{
    /// <summary>
    /// Contratos que são implementados para que apenas sejam ESCRITO dados no repositorio
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid Id);
        int SaveChanges();

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WM.SisControleMvc.Domain.Interfaces;
using WM.SisControleMvc.Domain.Models;
using WM.SisControleMvc.Infra.Data.Context;

namespace WM.SisControleMvc.Infra.Data.Repository
{
    /// <summary>
    /// Clase abstrata generica que manipula com leitura e/ou escrita os dados na base. As classes especializadas irao herdar essa classe para manipulação dos dados. 
    /// </summary> 
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected SisControleMvcContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(SisControleMvcContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
        }

        public virtual TEntity ObterPorId(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }
        
        public virtual IEnumerable<TEntity> ObterTodosPaginados(int s, int t)
        {
            return DbSet.Skip(s).Take(t).ToList();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            //tratamento especifico que possa ser feito no banco antes de salvar
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}

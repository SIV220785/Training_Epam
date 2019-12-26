using Bank.DAL.Contexts;
using Bank.DAL.DTO.Base;
using Ninject;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Bank.DAL.Repositories.Base
{
    public class GenericRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private bool _disposed;

        [Inject]
        protected BankContext Context { get; }

        public GenericRepository(BankContext context)
        {
            Context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable;
        }

        public virtual T Add(T t)
        {
            Context.Set<T>().Add(t);
            Context.SaveChanges();
            return t;
        }

        public virtual int Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChanges();
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = Context.Set<T>().Find(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(t);
                Context.SaveChanges();
            }
            return exist;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

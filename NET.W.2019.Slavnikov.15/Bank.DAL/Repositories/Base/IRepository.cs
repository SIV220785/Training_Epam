using Bank.DAL.DTO.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Bank.DAL.Repositories.Base
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Add(T t);
        int Delete(T entity);
        T Update(T t, object key);
        void Save();
        void Dispose();
    }
}

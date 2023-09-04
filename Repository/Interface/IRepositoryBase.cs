using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
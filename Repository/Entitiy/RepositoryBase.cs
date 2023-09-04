using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Entitiy
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected JiraBoardDbContext DbContext { get; set; }
        public RepositoryBase(JiraBoardDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IQueryable<T> GetAll() => DbContext.Set<T>().AsNoTracking();
        public IQueryable<T> Get(Expression<Func<T, bool>> expression) =>
            DbContext.Set<T>().Where(expression).AsNoTracking();
        public T Create(T entity)
        {
            var result = DbContext.Set<T>().Add(entity);
            if (result.State == EntityState.Added)
            {
                SaveChanges();
                return result.Entity;
            }
            
            return null;
        }

        public T Update(T entity)
        {
            var result = DbContext.Set<T>().Update(entity);
            if (result.State == EntityState.Modified)
            {
                SaveChanges();
                return result.Entity;
            }

            return null;
        }

        public bool Delete(T entity)
        {
            var result = DbContext.Set<T>().Remove(entity);
            if (result.State == EntityState.Deleted)
            {
                SaveChanges();
                return true;
            }
            return false;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}

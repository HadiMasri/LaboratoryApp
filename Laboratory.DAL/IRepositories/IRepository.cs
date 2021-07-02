using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Laboratory.DAL.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity t);
        TEntity FindById(int Id);
        List<TEntity> GetAll(Expression<Func<TEntity, object>> include1 = null, Expression<Func<TEntity, object>> include2 = null, Expression<Func<TEntity, bool>> Filter = null);
        void Remove(int id);
    }
}

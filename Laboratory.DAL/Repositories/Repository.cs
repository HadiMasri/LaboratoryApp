using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Laboratory.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity t)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, object>> include1 = null, Expression<Func<TEntity, object>> include2 = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Laboratory.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Laboratory.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        internal DbSet<TEntity> dbSet;

        public Repository(LaboratoryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this.dbSet = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity t)
        {
            var entity = _mapper.Map<TEntity>(t);
            dbSet.Add(entity);
        }

        public TEntity FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, object>> include1 = null, Expression<Func<TEntity, object>> include2 = null)
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

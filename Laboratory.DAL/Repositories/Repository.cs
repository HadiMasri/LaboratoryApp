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
            try
            {
                var entity = _mapper.Map<TEntity>(t);
                dbSet.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> Filter = null)
        {
            return dbSet.Where(Filter).FirstOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, object>> include1 = null, Expression<Func<TEntity, object>> include2 = null, Expression<Func<TEntity, object>> include3 = null, Expression<Func<TEntity, object>> include4 = null, Expression<Func<TEntity, bool>> Filter = null)
        {
            try
            {
                if (include1 != null && include2 != null && include3 != null && include4 != null && Filter != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Include(include2).Include(include3).Include(include4).Where(Filter).ToList();
                }
                else if (include1 != null && include2 != null && include3 != null && include4 != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Include(include2).Include(include3).Include(include4).ToList();
                }
                else if (include1 != null && include2 != null && include3 != null && Filter != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Include(include2).Include(include3).Where(Filter).ToList();
                }
                else if (include1 != null && include2 != null && include3 != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Include(include2).Include(include3).ToList();
                }
                else if (include1 != null && include2 != null && Filter != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Include(include2).Where(Filter).ToList();
                }
                else if (include1 != null && include2 != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Include(include2).ToList();
                }
                else if (include1 != null && Filter != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).Where(Filter).ToList();
                }
                else if (include1 != null)
                {
                    return _dbContext.Set<TEntity>().Include(include1).ToList();
                }
                else
                {
                    return _dbContext.Set<TEntity>().ToList();
                }
    
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

    }
}

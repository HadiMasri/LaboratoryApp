using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public UnitRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

    }
}

using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public TestRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(Test test)
        {
            try
            {
                var testFromDb = _dbContext.Tests.FirstOrDefault(s => s.Id == test.Id);
                if (testFromDb != null)
                {
                    testFromDb.Code = test.Code;
                    testFromDb.Name = test.Name;
                    testFromDb.Price = test.Price;
                    testFromDb.AppearName = test.AppearName;
                    testFromDb.CategoryId = test.CategoryId;
                    testFromDb.Note = test.Note;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
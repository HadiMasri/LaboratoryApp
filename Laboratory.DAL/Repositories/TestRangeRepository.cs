using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class TestRangeRepository : Repository<TestRange>, ITestRangeRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public TestRangeRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(TestRange testRange)
        {
            try
            {
                var testFromDb = _dbContext.TestRanges.FirstOrDefault(s => s.Id == testRange.Id);
                if (testFromDb != null)
                {
                    testFromDb.FromAge = testRange.FromAge;
                    testFromDb.ToAge = testRange.ToAge;
                    testFromDb.LowFrom = testRange.LowFrom;
                    testFromDb.HighFrom = testRange.HighFrom;
                    testFromDb.TestId = testRange.TestId;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
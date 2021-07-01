using Laboratory.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.IRepositories
{
    public interface ITestRangeRepository : IRepository<TestRange>
    {
        void Update(TestRange testRange);
    }
}

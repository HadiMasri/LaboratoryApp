using Laboratory.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.IRepositories
{
    public interface ITestRepository : IRepository<Test>
    {
        void Update(Test test);
    }
}

using Laboratory.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.IRepositories
{
    public interface ISettingRepository : IRepository<Setting>
    {
        void Update(Setting setting);
    }
}

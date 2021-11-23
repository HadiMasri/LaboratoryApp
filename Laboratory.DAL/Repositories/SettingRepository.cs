using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public SettingRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(Setting Setting)
        {
            try
            {
                var SettingFromDb = _dbContext.Settings.FirstOrDefault(s => s.Id == Setting.Id);
                if (SettingFromDb != null)
                {
                    SettingFromDb.Image = Setting.Image;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
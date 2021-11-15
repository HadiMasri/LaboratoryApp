using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public MaterialRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(Material material)
        {
            try
            {
                var materialFromDb = _dbContext.Materials.FirstOrDefault(s => s.Id == material.Id);
                if (materialFromDb != null)
                {
                    materialFromDb.Name = material.Name;
                    materialFromDb.Volume = material.Volume;
                    materialFromDb.OpenDate = material.OpenDate;
                    materialFromDb.ExpireDate = material.ExpireDate;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

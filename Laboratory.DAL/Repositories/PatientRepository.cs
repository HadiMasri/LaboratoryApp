using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public PatientRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Update(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}

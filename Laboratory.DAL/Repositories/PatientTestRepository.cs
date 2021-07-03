using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratory.DAL.Repositories
{
    public class PatientTestRepository : Repository<Patient_Test>, IPatientTestRepository
    {
        private LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public PatientTestRepository(LaboratoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(Patient_Test patient_Test)
        {
            try
            {
                var patientTestFromDb = _dbContext.Patient_Tests.FirstOrDefault(s => s.Id == patient_Test.Id);
                if (patientTestFromDb != null)
                {
                    patientTestFromDb.TestId = patient_Test.TestId;
                    patientTestFromDb.Test = patient_Test.Test;
                    patientTestFromDb.PatientId = patient_Test.PatientId;
                    patientTestFromDb.Patient = patient_Test.Patient;
                    patientTestFromDb.Result = patient_Test.Result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

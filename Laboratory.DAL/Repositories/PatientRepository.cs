using AutoMapper;
using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var patientFromDb = _dbContext.Patients.FirstOrDefault(s => s.Id == patient.Id);
                if (patientFromDb != null)
                {
                    patientFromDb.Title = patient.Title;
                    patientFromDb.TitleId = patient.TitleId;
                    patientFromDb.Name = patient.Name;
                    patientFromDb.LastName = patient.LastName;
                    patientFromDb.FatherName = patient.FatherName;
                    patientFromDb.MotherName = patient.MotherName;
                    patientFromDb.Age = patient.Age;
                    patientFromDb.ArriveTime = patient.ArriveTime;
                    patientFromDb.Gender = patient.Gender;
                    patientFromDb.GenderId = patient.GenderId;
                    patientFromDb.DoctorName = patient.DoctorName;
                    patientFromDb.RoomNr = patient.RoomNr;
                    patientFromDb.PhoneNr = patient.PhoneNr;
                    patientFromDb.Diagnosis = patient.Diagnosis;
                }
            }
            catch (Exception)
            {

                throw;
            }
 
        }
    }
}

using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.IRepositories
{
    public interface IPatientTestRepository : IRepository<Patient_Test>
    {
        void Update(Patient_Test patient_Test);
    }
}

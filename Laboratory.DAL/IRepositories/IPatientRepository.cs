using Laboratory.DAL.Entities;
using Laboratory.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.IRepositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);
    }
}

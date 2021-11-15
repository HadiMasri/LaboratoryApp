using Laboratory.DAL.IRepositories;
using System;

namespace Laboratory.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        ITitleRepository Title { get; }
        IGenderRepository Gender { get; }
        ICategoryRepository Category { get; }
        IDiscountTypeRepository DiscountType { get; }
        IUnitRepository Unit { get; }
        ITestRepository Test { get; }
        ITestRangeRepository TestRange { get; }
        IPatientTestRepository PatientTest { get; }
        IMaterialRepository Material { get; }


        void Save();
    }
}

using Laboratory.DAL.IRepositories;
using System;

namespace Laboratory.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        ITitleRepository Title { get; }
        IGenderRepository Gender { get; }

        void Save();
    }
}

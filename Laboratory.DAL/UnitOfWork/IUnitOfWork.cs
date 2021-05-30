using System;

namespace Laboratory.DAL.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {

        void Save();
    }
}

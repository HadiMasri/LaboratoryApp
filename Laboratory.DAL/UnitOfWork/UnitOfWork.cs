using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratory.DAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly LaboratoryDbContext _laboratoryDbContext;
        private IMapper _mapper;
        public UnitOfWork()
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}

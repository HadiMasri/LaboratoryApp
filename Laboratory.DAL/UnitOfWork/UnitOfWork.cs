using AutoMapper;


namespace Laboratory.DAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly LaboratoryDbContext _laboratoryDbContext;
        private IMapper _mapper;
        public UnitOfWork(LaboratoryDbContext laboratoryDbContext, IMapper mapper)
        {
            _laboratoryDbContext = laboratoryDbContext;
            _mapper = mapper;
        }
        public void Dispose()
        {
            _laboratoryDbContext.Dispose();
        }

        public void Save()
        {
             _laboratoryDbContext.SaveChanges();
        }
    }
}

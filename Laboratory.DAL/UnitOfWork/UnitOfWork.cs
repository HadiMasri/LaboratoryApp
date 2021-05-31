using AutoMapper;
using Laboratory.DAL.IRepositories;
using Laboratory.DAL.Repositories;

namespace Laboratory.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LaboratoryDbContext _dbContext;
        private IMapper _mapper;
        public UnitOfWork(LaboratoryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            Patient = new PatientRepository(_dbContext, _mapper);
            Title = new TitleRepository(_dbContext, _mapper);
            Gender = new GenderRepository(_dbContext, _mapper);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public IPatientRepository Patient { get; private set; }
        public ITitleRepository Title { get; private set; }
        public IGenderRepository Gender { get; private set; }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

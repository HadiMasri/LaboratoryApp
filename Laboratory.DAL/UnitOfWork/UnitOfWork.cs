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
            Test = new TestRepository(_dbContext, _mapper);
            Category = new CategoryRepository(_dbContext, _mapper);
            Unit = new UnitRepository(_dbContext, _mapper);
            TestRange = new TestRangeRepository(_dbContext, _mapper);
            PatientTest = new PatientTestRepository(_dbContext, _mapper);
            DiscountType = new DiscountTypeRepository(_dbContext, _mapper);
            Material = new MaterialRepository(_dbContext, _mapper);
            Setting = new SettingRepository(_dbContext, _mapper);


        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public IPatientRepository Patient { get; private set; }
        public IPatientTestRepository PatientTest { get; private set; }
        public ITitleRepository Title { get; private set; }
        public IGenderRepository Gender { get; private set; }
        public ITestRepository Test { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ISettingRepository Setting { get; private set; }
        public IMaterialRepository Material { get; private set; }
        public IDiscountTypeRepository DiscountType { get; private set; }
        public IUnitRepository Unit { get; private set; }
        public ITestRangeRepository TestRange { get; private set; }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

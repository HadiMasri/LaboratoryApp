using Laboratory.DAL.Configurations;
using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Laboratory.DAL.Extentions;


namespace Laboratory.DAL
{
    public class LaboratoryDbContext : DbContext
    {
        public LaboratoryDbContext(DbContextOptions<LaboratoryDbContext> options) : base(options)
        { }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Labo> Labos { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public DbSet<Patient_Test> Patient_Tests { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestRange> TestRanges { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Adress_Conf());
            modelBuilder.ApplyConfiguration(new Category_Conf());
            modelBuilder.ApplyConfiguration(new Labo_Conf());
            modelBuilder.ApplyConfiguration(new Patient_Conf());
            modelBuilder.ApplyConfiguration(new Test_Conf());
            modelBuilder.ApplyConfiguration(new Unit_Conf());
            modelBuilder.ApplyConfiguration(new TestRange_Conf());

            modelBuilder.seed();
        }
    }
}

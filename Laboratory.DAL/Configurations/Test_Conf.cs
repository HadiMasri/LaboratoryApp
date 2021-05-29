using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.DAL.Configurations
{
    public class Test_Conf : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(t => t.Name)
                 .IsRequired()
                 .HasMaxLength(50);
            builder.Property(t => t.Price)
                .IsRequired()
                .HasMaxLength(4);
            builder.Property(t => t.Sex)
                .IsRequired();
            builder.Property(t => t.Code)
               .IsRequired()
               .HasMaxLength(10);
            builder.Property(t => t.AppearName)
               .IsRequired()
               .HasMaxLength(50);
            builder.Property(t => t.Category)
              .IsRequired();
        }
    }
}

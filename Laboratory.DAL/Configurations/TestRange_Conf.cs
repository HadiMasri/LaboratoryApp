using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.DAL.Configurations
{
    public class TestRange_Conf : IEntityTypeConfiguration<TestRange>
    {
        public void Configure(EntityTypeBuilder<TestRange> builder)
        {
            builder.Property(t => t.ToAge)
                .IsRequired()
                .HasMaxLength(4);
            builder.Property(t => t.Test)
                .IsRequired();
            builder.Property(t => t.Range)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(t => t.Sex)
               .IsRequired();
            builder.Property(t => t.HighFrom)
               .IsRequired()
               .HasMaxLength(10);
            builder.Property(t => t.LowFrom)
               .IsRequired()
               .HasMaxLength(10);
            builder.Property(t => t.FromAge)
               .IsRequired()
               .HasMaxLength(4);
        }
    }
}

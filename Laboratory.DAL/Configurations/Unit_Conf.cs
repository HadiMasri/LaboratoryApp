using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.DAL.Configurations
{
    public class Unit_Conf : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(t => t.Name)
                           .IsRequired()
                           .HasMaxLength(10);
        }
    }
}

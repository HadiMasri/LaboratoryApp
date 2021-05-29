using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.DAL.Configurations
{
    public class Adress_Conf : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

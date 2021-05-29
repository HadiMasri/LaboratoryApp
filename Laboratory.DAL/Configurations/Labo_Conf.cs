using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.DAL.Configurations
{
    public class Labo_Conf : IEntityTypeConfiguration<Labo>
    {
        public void Configure(EntityTypeBuilder<Labo> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.PhoneNr)
                .IsRequired()
                .HasMaxLength(13);
        }
    }
}

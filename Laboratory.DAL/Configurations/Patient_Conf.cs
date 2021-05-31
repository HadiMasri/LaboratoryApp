using Laboratory.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.DAL.Configurations
{
    public class Patient_Conf : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(t => t.Title).WithMany().HasForeignKey(s => s.TitleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(t => t.Gender).WithMany().HasForeignKey(s => s.GenderId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(t => t.MotherName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.FatherName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.Age)
                .IsRequired()
                .HasMaxLength(3);
            builder.Property(t => t.RoomNr)
                .IsRequired()
                .HasMaxLength(13);
            builder.Property(t => t.ArriveTime)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(t => t.DoctorName)
                .HasMaxLength(50);
            builder.Property(t => t.Diagnosis)
               .HasMaxLength(50);
            builder.Property(t => t.PhoneNr)
               .HasMaxLength(13);
        }
    }
}

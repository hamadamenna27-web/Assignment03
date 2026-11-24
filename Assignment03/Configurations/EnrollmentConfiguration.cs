
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Assignment03.Models;

namespace Assignment03.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.StudentId, e.CourseId });

            builder.Property(e => e.EnrollmentDate)
                   .IsRequired();

            builder.Property(e => e.Progress)
                   .IsRequired();

            builder.Property(e => e.Status)
                   .IsRequired();

            builder.Property(e => e.FinalGrade)
                   .HasPrecision(5, 2);

            builder.HasOne<Student>()
                   .WithMany()
                   .HasForeignKey(e => e.StudentId);

            builder.HasOne<Course>()
                   .WithMany()
                   .HasForeignKey(e => e.CourseId);

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Enrollment_Progress",
                "[Progress] >= 0 AND [Progress] <= 100"
            ));
        }
    }
}

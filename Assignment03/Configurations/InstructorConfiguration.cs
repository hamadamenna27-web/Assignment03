using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Assignment03.Models;
#region InstructorConfiguration

//namespace Assignment03.Configurations
//{
//    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
//    {
//        public void Configure(EntityTypeBuilder<Instructor> builder)
//        {
//            builder.HasKey(i => i.Id);

//            builder.Property(i => i.FullName)
//                   .IsRequired()
//                   .HasMaxLength(100);

//            builder.Property(i => i.Email)
//                   .IsRequired()
//                   .HasMaxLength(150);

//            builder.Property(i => i.Bio)
//                   .HasMaxLength(500);

//            builder.Property(i => i.JoinedAt)
//                   .IsRequired();

//            builder.HasData(
//    new Instructor
//    {
//        Id = 1,
//        FullName = "Ahmed Mohamed",
//        Email = "ahmed@example.com",
//        Bio = "Backend Developer",
//        JoinedAt = new DateTime(2024, 1, 1)
//    },
//    new Instructor
//    {
//        Id = 2,
//        FullName = "Sara Ali",
//        Email = "sara@example.com",
//        Bio = "Frontend Developer",
//        JoinedAt = new DateTime(2024, 3, 1)
//    }
//     );
//        }

//    }


//}
#endregion

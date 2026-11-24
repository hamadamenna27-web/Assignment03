
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Assignment03.Models;
#region StudentConfiguration

//namespace Assignment03.Configurations
//{
//    public class StudentConfiguration : IEntityTypeConfiguration<Student>
//    {
//        public void Configure(EntityTypeBuilder<Student> builder)
//        {
//            builder.HasKey(s => s.Id);

//            builder.Property(s => s.FullName)
//                   .IsRequired()
//                   .HasMaxLength(100);

//            builder.Property(s => s.Email)
//                   .IsRequired()
//                   .HasMaxLength(150);

//            builder.Property(s => s.DateOfBirth)
//                   .IsRequired();


//            builder.HasData(
//    new Student
//    {
//        Id = 1,
//        FullName = "Omar Hassan",
//        Email = "omar@example.com",
//        DateOfBirth = new DateTime(2003, 5, 10)
//    },
//    new Student
//    {
//        Id = 2,
//        FullName = "Mona Ahmed",
//        Email = "mona@example.com",
//        DateOfBirth = new DateTime(2003, 8, 15)
//    },
//    new Student
//    {
//        Id = 3,
//        FullName = "Ali Mahmoud",
//        Email = "ali@example.com",
//        DateOfBirth = new DateTime(2001, 3, 20)
//    }
//);
//        }
//    }
//}
#endregion

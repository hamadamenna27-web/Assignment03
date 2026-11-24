
using Assignment03.Enums;
using Assignment03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment03.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

            builder.Property(c => c.Price)
                   .HasPrecision(10, 2);

            builder.Property(c => c.Level)
                   .IsRequired();

            builder.Property(c => c.IsPublished)
                   .IsRequired();

            builder.Property(c => c.PublishedAt)
                   .IsRequired(false);

            builder.HasOne(c => c.Instructor)
                   .WithMany()
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                   .WithMany()
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
    new Course
    {
        Id = 1,
        Title = "C# Fundamentals",
        Description = "Learn C# basics",
        Price = 500,
        Level = CourseLevel.Beginner,
        IsPublished = true,
        PublishedAt = new DateTime(2024, 3, 1),
        InstructorId = 1,
        CategoryId = 3
    },
    new Course
    {
        Id = 2,
        Title = "ASP.NET Core",
        Description = "Learn backend development",
        Price = 800,
        Level = CourseLevel.Intermediate,
        IsPublished = true,
        PublishedAt = new DateTime(2024, 4, 1),
        InstructorId = 1,
        CategoryId = 3
    },
    new Course
    {
        Id = 3,
        Title = "HTML and CSS",
        Description = "Learn frontend basics",
        Price = 400,
        Level = CourseLevel.Beginner,
        IsPublished = false,
        PublishedAt = null,
        InstructorId = 2,
        CategoryId = 4
    }
);
        }
    }
}

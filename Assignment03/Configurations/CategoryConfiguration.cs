
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Assignment03.Models;
#region Configurations

//namespace Assignment03.Configurations
//{
//    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
//    {
//        public void Configure(EntityTypeBuilder<Category> builder)
//        {
//            builder.HasKey(C => C.Id);

//            builder.Property(C => C.Name)
//                   .IsRequired()
//                   .HasMaxLength(100);

//            builder.Property(C => C.Description)
//                   .HasMaxLength(500);

//            builder.HasOne(C => C.ParentCategory)
//                   .WithMany(C => C.SubCategories)
//                   .HasForeignKey(C => C.ParentCategoryId)
//                   .OnDelete(DeleteBehavior.Restrict);

//            builder.HasData(
//    new Category
//    {
//        Id = 1,
//        Name = "Programming",
//        Description = "Programming courses",
//        ParentCategoryId = null
//    },
//    new Category
//    {
//        Id = 2,
//        Name = "Design",
//        Description = "Design courses",
//        ParentCategoryId = null
//    },
//    new Category
//    {
//        Id = 3,
//        Name = "Backend",
//        Description = "Backend development",
//        ParentCategoryId = 1
//    },
//    new Category
//    {
//        Id = 4,
//        Name = "Frontend",
//        Description = "Frontend development",
//        ParentCategoryId = 1
//    }
//);
//        }
//    }
//}
#endregion

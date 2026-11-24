using System;
using Assignment03;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
#region Migrations


//namespace Assignment03.Migrations
//{
//    [DbContext(typeof(LearningPlatformDbContext))]
//    partial class LearningPlatformDbContextModelSnapshot : ModelSnapshot
//    {
//        protected override void BuildModel(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .HasAnnotation("ProductVersion", "9.0.0")
//                .HasAnnotation("Relational:MaxIdentifierLength", 128);

//            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

//            modelBuilder.Entity("Assignment03.Models.Category", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<string>("Description")
//                        .HasMaxLength(500)
//                        .HasColumnType("nvarchar(500)");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasMaxLength(100)
//                        .HasColumnType("nvarchar(100)");

//                    b.Property<int?>("ParentCategoryId")
//                        .HasColumnType("int");

//                    b.HasKey("Id");

//                    b.HasIndex("ParentCategoryId");

//                    b.ToTable("Categories");

//                    b.HasData(
//                        new
//                        {
//                            Id = 1,
//                            Description = "Programming courses",
//                            Name = "Programming"
//                        },
//                        new
//                        {
//                            Id = 2,
//                            Description = "Design courses",
//                            Name = "Design"
//                        },
//                        new
//                        {
//                            Id = 3,
//                            Description = "Backend development",
//                            Name = "Backend",
//                            ParentCategoryId = 1
//                        },
//                        new
//                        {
//                            Id = 4,
//                            Description = "Frontend development",
//                            Name = "Frontend",
//                            ParentCategoryId = 1
//                        });
//                });

//            modelBuilder.Entity("Assignment03.Models.Course", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<int>("CategoryId")
//                        .HasColumnType("int");

//                    b.Property<string>("Description")
//                        .HasMaxLength(1000)
//                        .HasColumnType("nvarchar(1000)");

//                    b.Property<int>("InstructorId")
//                        .HasColumnType("int");

//                    b.Property<bool>("IsPublished")
//                        .HasColumnType("bit");

//                    b.Property<int>("Level")
//                        .HasColumnType("int");

//                    b.Property<decimal>("Price")
//                        .HasPrecision(10, 2)
//                        .HasColumnType("decimal(10,2)");

//                    b.Property<DateTime?>("PublishedAt")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Title")
//                        .IsRequired()
//                        .HasMaxLength(200)
//                        .HasColumnType("nvarchar(200)");

//                    b.HasKey("Id");

//                    b.HasIndex("CategoryId");

//                    b.HasIndex("InstructorId");

//                    b.ToTable("Courses");

//                    b.HasData(
//                        new
//                        {
//                            Id = 1,
//                            CategoryId = 3,
//                            Description = "Learn C# basics",
//                            InstructorId = 1,
//                            IsPublished = true,
//                            Level = 0,
//                            Price = 500m,
//                            PublishedAt = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                            Title = "C# Fundamentals"
//                        },
//                        new
//                        {
//                            Id = 2,
//                            CategoryId = 3,
//                            Description = "Learn backend development",
//                            InstructorId = 1,
//                            IsPublished = true,
//                            Level = 1,
//                            Price = 800m,
//                            PublishedAt = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                            Title = "ASP.NET Core"
//                        },
//                        new
//                        {
//                            Id = 3,
//                            CategoryId = 4,
//                            Description = "Learn frontend basics",
//                            InstructorId = 2,
//                            IsPublished = false,
//                            Level = 0,
//                            Price = 400m,
//                            Title = "HTML and CSS"
//                        });
//                });

//            modelBuilder.Entity("Assignment03.Models.Enrollment", b =>
//                {
//                    b.Property<int>("StudentId")
//                        .HasColumnType("int");

//                    b.Property<int>("CourseId")
//                        .HasColumnType("int");

//                    b.Property<DateTime>("EnrollmentDate")
//                        .HasColumnType("datetime2");

//                    b.Property<decimal?>("FinalGrade")
//                        .HasPrecision(5, 2)
//                        .HasColumnType("decimal(5,2)");

//                    b.Property<decimal>("Progress")
//                        .HasColumnType("decimal(18,2)");

//                    b.Property<int>("Status")
//                        .HasColumnType("int");

//                    b.HasKey("StudentId", "CourseId");

//                    b.HasIndex("CourseId");

//                    b.ToTable("Enrollments", t =>
//                        {
//                            t.HasCheckConstraint("CK_Enrollment_Progress", "[Progress] >= 0 AND [Progress] <= 100");
//                        });
//                });

//            modelBuilder.Entity("Assignment03.Models.Instructor", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<string>("Bio")
//                        .HasMaxLength(500)
//                        .HasColumnType("nvarchar(500)");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasMaxLength(150)
//                        .HasColumnType("nvarchar(150)");

//                    b.Property<string>("FullName")
//                        .IsRequired()
//                        .HasMaxLength(100)
//                        .HasColumnType("nvarchar(100)");

//                    b.Property<DateTime>("JoinedAt")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("Instructors");

//                    b.HasData(
//                        new
//                        {
//                            Id = 1,
//                            Bio = "Backend Developer",
//                            Email = "ahmed@example.com",
//                            FullName = "Ahmed Mohamed",
//                            JoinedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
//                        },
//                        new
//                        {
//                            Id = 2,
//                            Bio = "Frontend Developer",
//                            Email = "sara@example.com",
//                            FullName = "Sara Ali",
//                            JoinedAt = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
//                        });
//                });

//            modelBuilder.Entity("Assignment03.Models.Student", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<DateTime>("DateOfBirth")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasMaxLength(150)
//                        .HasColumnType("nvarchar(150)");

//                    b.Property<string>("FullName")
//                        .IsRequired()
//                        .HasMaxLength(100)
//                        .HasColumnType("nvarchar(100)");

//                    b.HasKey("Id");

//                    b.ToTable("Students");

//                    b.HasData(
//                        new
//                        {
//                            Id = 1,
//                            DateOfBirth = new DateTime(2002, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                            Email = "omar@example.com",
//                            FullName = "Omar Hassan"
//                        },
//                        new
//                        {
//                            Id = 2,
//                            DateOfBirth = new DateTime(2003, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                            Email = "mona@example.com",
//                            FullName = "Mona Ahmed"
//                        },
//                        new
//                        {
//                            Id = 3,
//                            DateOfBirth = new DateTime(2001, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
//                            Email = "ali@example.com",
//                            FullName = "Ali Mahmoud"
//                        });
//                });

//            modelBuilder.Entity("Assignment03.Models.Category", b =>
//                {
//                    b.HasOne("Assignment03.Models.Category", "ParentCategory")
//                        .WithMany("SubCategories")
//                        .HasForeignKey("ParentCategoryId")
//                        .OnDelete(DeleteBehavior.Restrict);

//                    b.Navigation("ParentCategory");
//                });

//            modelBuilder.Entity("Assignment03.Models.Course", b =>
//                {
//                    b.HasOne("Assignment03.Models.Category", "Category")
//                        .WithMany()
//                        .HasForeignKey("CategoryId")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .IsRequired();

//                    b.HasOne("Assignment03.Models.Instructor", "Instructor")
//                        .WithMany()
//                        .HasForeignKey("InstructorId")
//                        .OnDelete(DeleteBehavior.Restrict)
//                        .IsRequired();

//                    b.Navigation("Category");

//                    b.Navigation("Instructor");
//                });

//            modelBuilder.Entity("Assignment03.Models.Enrollment", b =>
//                {
//                    b.HasOne("Assignment03.Models.Course", null)
//                        .WithMany()
//                        .HasForeignKey("CourseId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("Assignment03.Models.Student", null)
//                        .WithMany()
//                        .HasForeignKey("StudentId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();
//                });

//            modelBuilder.Entity("Assignment03.Models.Category", b =>
//                {
//                    b.Navigation("SubCategories");
//                });
//        }
//    }
//}
#endregion

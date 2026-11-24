
using Assignment03.Models;
using Assignment03.Enums;
using Microsoft.EntityFrameworkCore;

namespace Assignment03
{
    internal class Program
    {
        static int instructorId;
        static int courseId;

        static int student1Id;
        static int student2Id;
        static int student3Id;

        static void Main(string[] args)
        {
           
                AddInstructor();
                AddCourse();
                AddStudents();

                PublishCourse();

                EnrollStudent(student1Id);
                EnrollStudent(student2Id);
                EnrollStudent(student3Id);

                FindCourse();
                FilterCourses();
                DisplayCategories();
                DisplayCourseRoster();

                ChangeCoursePrice();
                UpdateProgress(100);

                UnenrollStudent();
                TryDeleteCategory();
                SafeDeleteCategory();
                DeleteCourse();
            }

            static void AddInstructor()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Instructor instructor = new Instructor
                {
                    FullName = "Mohamed Samir",
                    Email = "mohamed@example.com",
                    Bio = "Software Developer",
                    JoinedAt = DateTime.Now
                };

                context.Instructors.Add(instructor);
                context.SaveChanges();

                instructorId = instructor.Id;

                Console.WriteLine($"Instructor added successfully. ID: {instructor.Id}");
            }
        }

        static void AddCourse()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                int categoryId = 3;

                bool instructorExists = context.Instructors.Any(i => i.Id == instructorId);
                bool categoryExists = context.Categories.Any(c => c.Id == categoryId);

                if (!instructorExists || !categoryExists)
                {
                    Console.WriteLine("Instructor or Category not found.");
                    return;
                }

                Course course = new Course
                {
                    Title = "Entity Framework Core",
                    Description = "Learn EF Core",
                    Price = 600,
                    Level = CourseLevel.Intermediate,
                    IsPublished = false,
                    PublishedAt = null,
                    InstructorId = instructorId,
                    CategoryId = categoryId
                };

                context.Courses.Add(course);
                context.SaveChanges();

                courseId = course.Id;

                Console.WriteLine($"Course added successfully. ID: {course.Id}");
            }
        }

        static void AddStudents()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                List<Student> students = new List<Student>
                {
                    new Student
                    {
                        FullName = "Omar Hassan",
                        Email = "omar.new@example.com",
                        DateOfBirth = new DateTime(2002, 5, 10)
                    },
                    new Student
                    {
                        FullName = "Mona Ahmed",
                        Email = "mona.new@example.com",
                        DateOfBirth = new DateTime(2003, 8, 15)
                    },
                    new Student
                    {
                        FullName = "Ali Mahmoud",
                        Email = "ali.new@example.com",
                        DateOfBirth = new DateTime(2001, 3, 20)
                    }
                };

                context.Students.AddRange(students);
                context.SaveChanges();

                student1Id = students[0].Id;
                student2Id = students[1].Id;
                student3Id = students[2].Id;

                Console.WriteLine($"Student 1 ID: {student1Id}");
                Console.WriteLine($"Student 2 ID: {student2Id}");
                Console.WriteLine($"Student 3 ID: {student3Id}");
            }
        }

        static void EnrollStudent(int studentId)
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Student? student = context.Students.Find(studentId);
                Course? course = context.Courses.Find(courseId);

                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                if (!course.IsPublished)
                {
                    Console.WriteLine("Cannot enroll. Course is not published.");
                    return;
                }

                bool alreadyEnrolled = context.Enrollments.Any(
                    e => e.StudentId == studentId && e.CourseId == course.Id);

                if (alreadyEnrolled)
                {
                    Console.WriteLine("Student is already enrolled.");
                    return;
                }

                Enrollment enrollment = new Enrollment
                {
                    StudentId = studentId,
                    CourseId = course.Id,
                    EnrollmentDate = DateTime.Now,
                    Progress = 0,
                    Status = EnrollmentStatus.Active,
                    FinalGrade = null
                };

                context.Enrollments.Add(enrollment);
                context.SaveChanges();

                Console.WriteLine($"Student {studentId} enrolled successfully.");
            }
        }

        static void FindCourse()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Course courseById = context.Courses.Find(courseId);

                if (courseById == null)
                    Console.WriteLine("Course not found by ID.");
                else
                    Console.WriteLine($"Found by ID: {courseById.Title}");

                Course courseByTitle = context.Courses.FirstOrDefault(
                    c => c.Title == "Entity Framework Core");

                if (courseByTitle == null)
                    Console.WriteLine("Course not found by title.");
                else
                    Console.WriteLine($"Found by Title: {courseByTitle.Title}");
            }
        }

        static void FilterCourses()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                var courses = context.Courses
                    .Where(c => c.Price >= 300 && c.Price <= 900)
                    .OrderByDescending(c => c.Price)
                    .Select(c => new
                    {
                        c.Title,
                        c.Level,
                        c.Price
                    })
                    .ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine(
                        $"{course.Title} - {course.Level} - {course.Price}");
                }
            }
        }

        static void DisplayCategories()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                var subCategories = context.Categories
                    .Where(c => c.ParentCategoryId == 1)
                    .ToList();

                Console.WriteLine("Sub-categories:");

                foreach (var category in subCategories)
                    Console.WriteLine(category.Name);

                var topCategories = context.Categories
                    .Where(c => c.ParentCategoryId == null)
                    .ToList();

                Console.WriteLine("Top-level Categories:");

                foreach (var category in topCategories)
                    Console.WriteLine(category.Name);
            }
        }

        static void DisplayCourseRoster()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                int targetCourseId = courseId;

                var studentIds = context.Enrollments
                    .Where(e => e.CourseId == targetCourseId)
                    .Select(e => e.StudentId)
                    .ToList();

                var students = context.Students
                    .Where(s => studentIds.Contains(s.Id))
                    .ToList();

                Console.WriteLine($"Number of enrolled students: {students.Count}");

                foreach (var student in students)
                    Console.WriteLine(student.FullName);
            }
        }

        static void ChangeCoursePrice()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Course course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                course.Price = 750;

                context.SaveChanges();

                Console.WriteLine("Course price updated successfully.");
            }
        }

        static void UpdateProgress(decimal newProgress)
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Enrollment enrollment = context.Enrollments.Find(student1Id, courseId);

                if (enrollment == null)
                {
                    Console.WriteLine("Enrollment not found.");
                    return;
                }

                if (newProgress < 0 || newProgress > 100)
                {
                    Console.WriteLine("Progress must be between 0 and 100.");
                    return;
                }

                enrollment.Progress = newProgress;

                if (newProgress == 100)
                {
                    enrollment.Status = EnrollmentStatus.Completed;
                    enrollment.FinalGrade = 95;
                }
                else
                {
                    enrollment.Status = EnrollmentStatus.Active;
                    enrollment.FinalGrade = null;
                }

                context.SaveChanges();

                Console.WriteLine("Enrollment progress updated successfully.");
            }
        }

        static void PublishCourse()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Course course = context.Courses.Find(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                course.IsPublished = true;
                course.PublishedAt = DateTime.Now;

                context.SaveChanges();

                Console.WriteLine("Course published successfully.");
            }
        }

        static void UnenrollStudent()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Enrollment enrollment = context.Enrollments.Find(student3Id, courseId);

                if (enrollment == null)
                {
                    Console.WriteLine("Enrollment not found.");
                    return;
                }

                context.Enrollments.Remove(enrollment);
                context.SaveChanges();

                Console.WriteLine("Student unenrolled successfully.");
            }
        }

        static void TryDeleteCategory()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                Category category = context.Categories.Find(1);

                if (category == null)
                {
                    Console.WriteLine("Category not found.");
                    return;
                }

                context.Categories.Remove(category);

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Cannot delete category because it has sub-categories.");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void SafeDeleteCategory()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                int categoryId = 4;

                Category category = context.Categories.Find(categoryId);

                if (category == null)
                {
                    Console.WriteLine("Category not found.");
                    return;
                }

                bool hasSubCategories = context.Categories.Any(
                    c => c.ParentCategoryId == categoryId);

                if (hasSubCategories)
                {
                    Console.WriteLine("Cannot delete category. It has sub-categories.");
                    return;
                }

                context.Categories.Remove(category);

                try
                {
                    context.SaveChanges();
                    Console.WriteLine("Category deleted successfully.");
                }
                catch (DbUpdateException)
                {
                    Console.WriteLine("Cannot delete category because it is used by courses.");
                }
            }
        }

        static void DeleteCourse()
        {
            using (LearningPlatformDbContext context = new LearningPlatformDbContext())
            {
                int targetCourseId = courseId;

                Course course = context.Courses.Find(targetCourseId);

                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                int beforeCount = context.Enrollments.Count(
                    e => e.CourseId == targetCourseId);

                Console.WriteLine($"Enrollments before deletion: {beforeCount}");

                context.Courses.Remove(course);
                context.SaveChanges();

                // Enrollments are deleted automatically because the Course relationship
                // uses EF Core's default Cascade delete behavior.

                int afterCount = context.Enrollments.Count(
                    e => e.CourseId == targetCourseId);

                Console.WriteLine($"Enrollments after deletion: {afterCount}");
                Console.WriteLine("Course deleted successfully.");
            }
        }
    }
}

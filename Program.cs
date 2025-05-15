using EF_Core_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var courses = context.Courses;
                Console.WriteLine(courses.ToQueryString());

                Console.WriteLine("\n");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Course name: {course.CourseName}, {course.HoursToComplete} hrs, {course.Price.ToString("C")}");
                }
            }

            Console.ReadKey();
        }
    }
}


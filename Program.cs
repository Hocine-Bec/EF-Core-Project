using EF_Core_Project.Data;
using EF_Core_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace EF_Core_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //FromSql -- newest version
                //FromSqlInterpolated -- prev version
                //FromSqlRaw -- older version


                //var course = context.Courses.Find(1);

                //Console.WriteLine($"{course.CourseName} ({course.HoursToComplete})");

                //var course1 = context.Courses
                ////     Turns 1 into a sql param to prevent Sql Injection
                //    .FromSql($"SELECT * FROM Courses WHERE Id = {1}") 
                //    .FirstOrDefault();

                //Console.WriteLine($"{course1.CourseName} ({course1.HoursToComplete})");

                //var course2 = context.Courses
                ////     Turns 1 into a sql param to prevent Sql Injection
                //    .FromSqlInterpolated($"SELECT * FROM Courses WHERE Id = {1}")
                //    .FirstOrDefault();

                //Console.WriteLine($"{course2.CourseName} ({course2.HoursToComplete})");

                var course3 = context.Courses
                    .FromSqlRaw("SELECT * FROM Courses WHERE Id = {1}")//No sql param, directly uses 1
                    .FirstOrDefault();

                Console.WriteLine($"{course3.CourseName} ({course3.HoursToComplete})");
            }
        }
    }
}


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
                int pageNumber = 1;
                int pageSize = 10;
                int totalSections = context.Sections.Count();
                int totalPages = (int) Math.Ceiling((double)totalSections / pageSize);

                var query = context.Sections.AsNoTracking()
                   .Include(x => x.Course)
                   .Include(x => x.Instructor)
                   .Include(x => x.Schedule)
                   .Select(x =>
                   new
                   {
                       Course = x.Course.CourseName,
                       Instructor = x.Instructor.FullName,
                       DateRange = x.DateRange.ToString(),
                       TimeSlot = x.TimeSlot.ToString(),
                       Days = string.Join(" ",   // "SAT SUN MON"
                              x.Schedule.SUN ? "SUN" : "   ",
                              x.Schedule.SAT ? "SAT" : "   ",
                              x.Schedule.MON ? "MON" : "   ",
                              x.Schedule.TUE ? "TUE" : "   ",
                              x.Schedule.WED ? "WED" : "   ",
                              x.Schedule.THU ? "THU" : "   ",
                              x.Schedule.FRI ? "FRI" : "   ")
                   });

                while (pageNumber <= totalPages)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("|           Course                   |          Instructor            |       Date Range        |   Time Slot   |            Days                |");
                    Console.WriteLine("|------------------------------------|--------------------------------|-------------------------|---------------|--------------------------------|");

                    var queryResult = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                    foreach (var section in queryResult)
                    {
                        Console.WriteLine($"| {section.Course,-34} | {section.Instructor,-30} | {section.DateRange.ToString(),-23} | {section.TimeSlot.ToString(),-12} | {section.Days,-30} |");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n\n\t\t\t\t{pageNumber}");
                    Console.ResetColor();
                    Console.WriteLine($" .....  {totalPages}");
                    Console.ReadKey();
                    ++pageNumber;
                }

                Console.ReadKey();
            }
        }
    }
}


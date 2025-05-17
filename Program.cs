using EF_Core_Project.Data;
using EF_Core_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EF_Core_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            //using (var context = new AppDbContext())
            //{
            //    var sectionQuery = context.Sections
            //        .Include(x => x.Participants)
            //        .Where(x => x.Id == 1);

            //    Console.WriteLine(sectionQuery.ToQueryString());

            //    var section = sectionQuery.FirstOrDefault();

            //    Console.WriteLine($"\nSection Name: {section.SectionName}");

            //    foreach (var part in section.Participants)
            //    {
            //        Console.WriteLine($"\n[{part.Id}] {part.FName} {part.LName}");
            //    }
            //}

            using (var context = new AppDbContext())
            {
                var sectionQuery = context.Sections
                    .Include(x => x.Instructor)
                    .ThenInclude(x => x.Office)
                    .Where(x => x.Id == 1);

                Console.WriteLine(sectionQuery.ToQueryString());

                var section = sectionQuery.FirstOrDefault();

                Console.WriteLine($"\nSection Name: {section.SectionName}\n");

                Console.WriteLine($"[{section.Id}] " +
                    $"{section.Instructor.FName} {section.Instructor.LName} " +
                    $"[{section.Instructor.Office.OfficeName}]");
            }

            Console.ReadKey();
        }
    }
}


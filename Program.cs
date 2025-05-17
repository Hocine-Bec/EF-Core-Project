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
            //    var section = context.Sections.FirstOrDefault(x => x.Id == 1);

            //    Console.WriteLine("Before changing tracked object");
            //    Console.WriteLine("-------------------------------");
            //    Console.WriteLine(section.SectionName); //01A51C05

            //    section.SectionName = "BlaBla";
            //    context.SaveChanges();

            //    Console.WriteLine("\nAfter changing tracked object");
            //    Console.WriteLine("-------------------------------");

            //    section = context.Sections.FirstOrDefault(x => x.Id == 1);
            //    Console.WriteLine(section.SectionName);
            //}

            using (var context = new AppDbContext())
            {
                var section = context.Sections
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == 1);

                Console.WriteLine("Before changing tracked object");
                Console.WriteLine("-------------------------------");
                Console.WriteLine(section.SectionName); //BlaBla

                section.SectionName = "01A51C05";
                context.SaveChanges();

                Console.WriteLine("\nAfter changing tracked object");
                Console.WriteLine("-------------------------------");

                section = context.Sections.FirstOrDefault(x => x.Id == 1);
                Console.WriteLine(section.SectionName);
            }

            Console.ReadKey();
        }
    }
}


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
            using (var context = new AppDbContext())
            {
                var section = context.Sections
                    .FirstOrDefault(x => x.Id == 1);

                var query = context.Entry(section).Collection(x => x.Participants).Query();
                Console.WriteLine(query.ToQueryString());

                Console.WriteLine($"\nSection Name: {section.SectionName}");

                foreach (var part in query)
                {
                    Console.WriteLine($"\n[{part.Id}] {part.FName} {part.LName}");
                }
            }

            Console.ReadKey();
        }
    }
}


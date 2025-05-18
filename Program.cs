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
                //SELECT MANY
                //var querySyntax = (from c in context.Courses
                //                   where c.CourseName.Contains("frontend") // Angular and react
                //                   from s in c.Sections
                //                   from p in s.Participants
                //                   select new
                //                   {
                //                       PName = p.FullName,
                //                   }).ToList();


                var methodSyntex = context.Courses
                    .Where(c => c.CourseName.Contains("frontend"))
                    .SelectMany(s => s.Sections)
                    .SelectMany(p => p.Participants)
                    .Select(x => new
                    {
                        PName = x.FullName
                    });
                  
                foreach (var item in methodSyntex)
                {
                    Console.WriteLine(item.PName);
                }
            }
        }
    }
}


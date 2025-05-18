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
                ////Group By
                //// Multiple Queries
                //var querySyntax = (from s in context.Sections
                //                   group s by s.Instructor into g
                //                   select new
                //                   {
                //                       key = g.Key,
                //                       Sections = g.ToList()
                //                   }).ToList();

                //// One query using aggregate funcs
                //var querySyntax = (from s in context.Sections
                //                   group s by s.Instructor into g
                //                   select new
                //                   {
                //                       key = g.Key,
                //                       TotalSections = g.Count()
                //                   }).ToList();


                //// Multiple Queries
                //var methodSyntex = context.Sections
                //    .GroupBy(x => x.Instructor)
                //    .Select(x => new
                //    {
                //        key = x.Key,
                //        Sections = x.ToList(),
                //    }).ToList();

                //// One query using aggregate funcs
                var methodSyntex = context.Sections
                    .GroupBy(x => x.Instructor)
                    .Select(x => new
                    {
                        key = x.Key,
                        Total = x.Count(),
                    }).ToList();

                foreach (var item in methodSyntex)
                {
                    Console.WriteLine($"{item.key.FullName} => Total Sections: {item.Total}");
                }

            }
        }
    }
}


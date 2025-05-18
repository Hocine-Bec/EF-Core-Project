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
                ////Cross Join Using Query Syntax
                //var querySyntax = (from s in context.Sections
                //                   from i in context.Instructors
                //                   select new
                //                   {
                //                      s.SectionName,
                //                      i.FullName
                //                   }).ToList();

                //Console.WriteLine(querySyntax.Count());

                // Cross Join Using Method Syntex
                var methodSyntex = context.Sections
                    .SelectMany
                    (
                        s => context.Instructors,
                        (s, i) => new { s.SectionName, i.FullName }
                    ).ToList();

                Console.WriteLine(methodSyntex.Count());
            }
        }
    }
}


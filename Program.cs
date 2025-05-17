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
                ////Inner Join Using Query Syntax
                //var querySyntax = (from c in context.Courses.AsNoTracking()
                //              join s in context.Sections.AsNoTracking()
                //                     on c.Id equals s.CourseId
                //              select new
                //              {
                //                  c.CourseName,
                //                  DateRange = s.DateRange.ToString(),
                //                  TimeSlot = s.TimeSlot.ToString(),
                //              }).ToList();

                // Inner Join Using Method Syntex
                var methodSyntex = context.Courses.AsNoTracking()
                    .Join(context.Sections.AsNoTracking(),
                    c => c.Id,
                    s => s.CourseId,
                    (c, s) => new
                    {
                        c.CourseName,
                        DateRange = s.DateRange.ToString(),
                        TimeSlot = s.TimeSlot.ToString(),
                    }).ToList();
            }

            Console.ReadKey();
        }
    }
}


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
                //// proper projection (select) reduce network traffic
                //// and reduce the effect on app performance
                //var coursesProjection = context.Courses.AsNoTracking()
                //    .Select(c => new
                //    {
                //        CourseId = c.Id,
                //        CourseName = c.CourseName,
                //        Hours = c.HoursToComplete,
                //        Sections = c.Sections.Select(s => 
                //        new
                //        {
                //            SectionId = s.Id,
                //            SectionName = s.SectionName,
                //            DateRange = s.DateRange.ToString(),
                //            TimeSlot = s.TimeSlot.ToString()
                //        }),
                //        Reviews = c.Reviews.Select(r =>
                //        new
                //        {
                //            FeedBack = r.Feedback,
                //            CreatedAt = r.CreatedAt
                //        })
                //    }).ToList();   
            }

            using (var context = new AppDbContext())
            {
                //var courses = context.Courses
                //    .Include(x => x.Sections)
                //    .Include(x => x.Reviews) // Cartesian Problem
                //    .ToList();

                //var courses = context.Courses
                //  .AsNoTracking()
                //  .Include(x => x.Sections)
                //  .Include(x => x.Reviews)
                //  .AsSplitQuery() // Explicit Split
                //  .ToList();

                //var courses = context.Courses
                //  .AsNoTracking()
                //  .Include(x => x.Sections)
                //  .Include(x => x.Reviews) // Split By Config
                //  .ToList();

                var courses = context.Courses
                  .AsNoTracking()
                  .Include(x => x.Sections)
                  .Include(x => x.Reviews)
                  .AsSingleQuery() // Explicit Single Querying The Data
                  .ToList();
            }

            Console.ReadKey();
        }
    }
}


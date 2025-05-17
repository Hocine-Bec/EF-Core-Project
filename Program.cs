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
                ////Left Join Using Query Syntax
                //var querySyntax = (from o in context.Offices
                //                   join i in context.Instructors
                //                   on o.Id equals i.OfficeId into officeVacancy
                //                   from ov in officeVacancy.DefaultIfEmpty()
                //                   select new
                //                   {
                //                       OfficeId = o.Id,
                //                       Name = o.OfficeName,
                //                       Location = o.OfficeLocation,
                //                       instructor = ov != null ? ov.FullName : "<<Empty>>"
                //                   }).ToList();

                //foreach (var item in querySyntax)
                //{
                //    Console.WriteLine($"{item.Name} => {item.instructor}");
                //}

                // Inner Join Using Method Syntex
                var methodSyntex = context.Offices
                    .GroupJoin
                    (   
                        context.Instructors,
                        o => o.Id,
                        i => i.OfficeId,
                        (Office, Instructor) => new { Office, Instructor } 
                    )
                    .SelectMany
                    ( 
                        ov => ov.Instructor.DefaultIfEmpty(),
                        (ov, Instructor) => new
                        {
                            OfficeId = ov.Office.Id,
                            Name = ov.Office.OfficeName,
                            Location = ov.Office.OfficeLocation,
                            instructor = Instructor != null ? Instructor.FullName : "<<Empty>>"
                        }
                    ).ToList();

                foreach (var item in methodSyntex)
                {
                    Console.WriteLine($"{item.Name} => {item.instructor}");
                }
            }

            Console.ReadKey();
        }
    }
}


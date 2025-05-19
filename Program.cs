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
                foreach (var sec in context.Sections)
                {
                    Console.WriteLine($"[{sec.Id}]\t{sec.SectionName}\t{sec.DateRange.StartDate.ToString()}");
                }
            }
        }
    }
}


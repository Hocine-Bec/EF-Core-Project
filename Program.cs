using EF_Core_Project.Data;
using Microsoft.Extensions.Configuration;

namespace EF_Core_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var instructors = context.Instructors.ToList();

                Console.WriteLine("Before Deleting:");
                foreach (var instructor in instructors)
                {
                    Console.WriteLine($"- ID: [{instructor.Id}]\tFullName: {instructor.FullName, 15}\t\tIs Deleted: {instructor.IsDeleted}\tDeleted Date:{instructor.DateDeleted}");
                }
                Console.WriteLine();

                var inst = context.Instructors.First();
                context.Instructors.Remove(inst);
                context.SaveChanges();

                Console.WriteLine("After Deleting Instructor With ID = 1:");
                foreach (var instructor in instructors)
                {
                    Console.WriteLine($"- ID: [{instructor.Id}]\tFullName: {instructor.FullName, 15}\t\tIs Deleted: {instructor.IsDeleted}\tDeleted Date:{instructor.DateDeleted}");
                }
            }
        }
    }
}


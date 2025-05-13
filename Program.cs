using EF010.CodeFirstMigration.Data;
using EF010.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF010.CodeFirstMigration
{
    class Program
    {
        public static void Main(string[] args)
        {
            var participant1 = new Individual()
            {
                Id = 1,
                FName = "Ahmed",
                LName = "Ali",
                University = "JUST",
                YearOfGrad = 2024,
                IsIntern = false
            };
            var participant2 = new Corporate()
            {
                Id = 2,
                FName = "Ahmed",
                LName = "Ali",
                Company = "Metigator",
                JobTitle = "Software Engineer"
            };

            using (var context = new AppDbContext())
            {
                context.Participants.Add(participant1);
                context.Participants.Add(participant2);
                context.SaveChanges();
            }

            using (var context = new AppDbContext())
            {
                Console.WriteLine("Individual Participants:");
                foreach (var participant in context.Participants.OfType<Individual>())
                {
                    Console.WriteLine(participant);
                }
                Console.WriteLine();
                Console.WriteLine("Corporate Participants:");
                foreach (var participant in context.Participants.OfType<Individual>())
                {
                    Console.WriteLine(participant);
                }
            }

            Console.ReadKey();
        }
    }
}


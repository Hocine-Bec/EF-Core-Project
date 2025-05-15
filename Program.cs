using EF010.CodeFirstMigration.Data;
using EF010.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF010.CodeFirstMigration
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                await context.Database.EnsureCreatedAsync();
                var query = context.Database.GenerateCreateScript();

                await Task.Delay(10000);

                await context.Database.EnsureDeletedAsync();
            }

            Console.ReadKey();
        }
    }
}


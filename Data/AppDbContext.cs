using EF_Core_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_Core_Project.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Participant> Particpants { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<Config.Converter>()
                .HaveColumnType("date");
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

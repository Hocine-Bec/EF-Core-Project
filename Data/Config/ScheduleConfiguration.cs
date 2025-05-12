using EF_Core_Project.Enums;
using EF010.CodeFirstMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.CodeFirstMigration.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasConversion
                (
                    v => v.ToString(),
                    v => (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), v)
                );

            builder.ToTable("Schedules");
        }
    }
}

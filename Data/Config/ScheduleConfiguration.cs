using EF_Core_Project;
using EF_Core_Project.Enums;
using EF_Core_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Project.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.ScheduleType)
                .HasConversion(
                     x => x.ToString(),
                     x => (ScheduleType)Enum.Parse(typeof(ScheduleType), x)
                );

            builder.ToTable("Schedules");
        }
    }
}

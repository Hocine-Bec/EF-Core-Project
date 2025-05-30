﻿using EF_Core_Project;
using EF_Core_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Project.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);

            builder.ToTable("Courses");
        }
    }
}

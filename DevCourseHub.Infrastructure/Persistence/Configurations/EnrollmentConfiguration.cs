using DevCourseHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Infrastructure.Persistence.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EnrolledAt)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasIndex(x => new { x.UserId, x.CourseId })
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

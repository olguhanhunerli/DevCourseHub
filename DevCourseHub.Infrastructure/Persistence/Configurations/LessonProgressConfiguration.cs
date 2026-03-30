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
    public class LessonProgressConfiguration : IEntityTypeConfiguration<LessonProgress>
    {
        public void Configure(EntityTypeBuilder<LessonProgress> builder)
        {
            builder.ToTable("LessonProgresses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsCompleted)
                .IsRequired();

            builder.Property(x => x.CompletedAt);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasIndex(x => new { x.UserId, x.LessonId })
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(x => x.LessonProgresses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Lesson)
                .WithMany(x => x.LessonProgresses)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

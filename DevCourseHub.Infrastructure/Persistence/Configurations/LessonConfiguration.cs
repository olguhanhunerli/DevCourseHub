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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.VideoUrl)
                .HasMaxLength(500);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.DurationInMinutes)
                .IsRequired();

            builder.Property(x => x.IsPreview)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}

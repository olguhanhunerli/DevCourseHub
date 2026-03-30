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
    public class CourseReviewConfiguration : IEntityTypeConfiguration<CourseReview>
    {
        public void Configure(EntityTypeBuilder<CourseReview> builder)
        {
            builder.ToTable("CourseReviews");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.Comment)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => new { x.UserId, x.CourseId })
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(x => x.CourseReviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

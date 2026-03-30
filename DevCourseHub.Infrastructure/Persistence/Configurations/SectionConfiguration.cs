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
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DisplayOrder)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasMany(x => x.Lessons)
                .WithOne(x => x.Section)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

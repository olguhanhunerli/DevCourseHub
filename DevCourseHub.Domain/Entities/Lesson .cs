using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public Guid SectionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? VideoUrl { get; set; }
        public int DisplayOrder { get; set; }
        public int DurationInMinutes { get; set; }
        public bool IsPreview { get; set; } = false;

        public Section Section { get; set; } = null!;
        public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
    }
}

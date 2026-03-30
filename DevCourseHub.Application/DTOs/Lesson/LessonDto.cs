using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Lesson
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? VideoUrl { get; set; }
        public int DisplayOrder { get; set; }
        public int DurationInMinutes { get; set; }
        public bool IsPreview { get; set; }
    }
}

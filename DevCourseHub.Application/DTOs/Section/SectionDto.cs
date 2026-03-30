using DevCourseHub.Application.DTOs.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Section
{
    public class SectionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public List<LessonDto> Lessons { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Progress
{
    public class CourseProgressDto
    {
        public Guid CourseId { get; set; }
        public int TotalLessons { get; set; }
        public int CompletedLessons { get; set; }
        public double Percentage { get; set; }
        public List<LessonProgressDto> Lessons { get; set; } = new();
    }
}

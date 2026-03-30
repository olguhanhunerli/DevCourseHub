using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Progress
{
    public class LessonProgressDto
    {
        public Guid LessonId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

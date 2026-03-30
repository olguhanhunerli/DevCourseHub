using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Domain.Entities
{
    public class LessonProgress : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }

        public User User { get; set; } = null!;
        public Lesson Lesson { get; set; } = null!;
    }
}

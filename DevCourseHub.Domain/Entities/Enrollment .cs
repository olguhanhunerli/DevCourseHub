using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Domain.Entities
{
    public class Enrollment : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}

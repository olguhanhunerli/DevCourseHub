using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Domain.Entities
{
    public class CourseReview : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Domain.Entities
{
    public class Section : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }

        public Course Course { get; set; } = null!;
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
}

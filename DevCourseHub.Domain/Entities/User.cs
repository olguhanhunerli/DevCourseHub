using DevCourseHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Domain.Entities
{
    public class User: BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Student;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
        public ICollection<CourseReview> CourseReviews { get; set; } = new List<CourseReview>();
    }
}

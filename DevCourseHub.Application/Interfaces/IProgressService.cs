using DevCourseHub.Application.DTOs.Progress;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface IProgressService
    {
        Task<LessonProgressDto> CompleteLessonAsync(Guid lessonId);
        Task<LessonProgressDto> MarkLessonInCompleteAsync(Guid lessonId);
        Task<CourseProgressDto> GetCourseProgressAsync(Guid courseId);
    }
}

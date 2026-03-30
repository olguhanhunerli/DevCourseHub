using DevCourseHub.Application.DTOs.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDto?> GetLessonByIdAsync(Guid lessonId);
        Task<LessonDto> CreateLessonAsync(Guid sectionId,CreateLessonDto createLessonDto);
        Task<LessonDto?> UpdateLessonAsync(Guid lessonId, UpdateLessonDto updateLessonDto);
        Task<bool> DeleteLessonAsync(Guid lessonId);
    }
}

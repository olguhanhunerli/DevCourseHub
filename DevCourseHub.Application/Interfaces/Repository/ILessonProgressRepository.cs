using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface ILessonProgressRepository : IGenericRepository<Domain.Entities.LessonProgress>
    {
        Task<LessonProgress?> GetByUserAndLessonAsync(Guid userId, Guid lessonId);
        Task<List<LessonProgress>> GetByUserAndCourseAsync(Guid userId, Guid courseId);

    }
}

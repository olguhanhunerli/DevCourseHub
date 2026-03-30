using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<Lesson> GetWithSectionAndCourseAsync(Guid lessonId);
        Task<IEnumerable<Lesson>> GetBySectionIdAsync(Guid sectionId);
    }
}

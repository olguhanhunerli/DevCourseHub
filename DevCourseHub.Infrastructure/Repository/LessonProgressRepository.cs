using DevCourseHub.Application.Interfaces.Repository;
using DevCourseHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Infrastructure.Repository
{
    public class LessonProgressRepository : GenericRepository<LessonProgress>, ILessonProgressRepository
    {
        public LessonProgressRepository(DevCourseHub.Infrastructure.Persistence.AppDbContext context) : base(context)
        {
        }
        public async Task<List<LessonProgress>> GetByUserAndCourseAsync(Guid userId, Guid courseId)
        {
            return await _context.LessonProgresses
                .Include(x => x.Lesson)
                .ThenInclude(x => x.Section)
                .Where(x => x.UserId == userId && x.Lesson.Section.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<LessonProgress?> GetByUserAndLessonAsync(Guid userId, Guid lessonId)
        {
            return await _context.LessonProgresses
                .Include(x => x.Lesson)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.LessonId == lessonId);
        }
    }
}

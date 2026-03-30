using DevCourseHub.Application.Interfaces.Repository;
using DevCourseHub.Domain.Entities;
using DevCourseHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Infrastructure.Repository
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Lesson>> GetBySectionIdAsync(Guid sectionId)
        {
            return await _context.Lessons
                .Where(l => l.SectionId == sectionId)
                .OrderByDescending(l => l.DisplayOrder)
                .ToListAsync();
        }

        public async Task<Lesson> GetWithSectionAndCourseAsync(Guid lessonId)
        {
            return await _context.Lessons
                .Include(l => l.Section)
                    .ThenInclude(s => s.Course)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }
    }
}

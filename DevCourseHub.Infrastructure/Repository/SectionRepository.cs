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
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Section>> GetByCourseIdAsync(Guid courseId)
        {
            return await _context.Sections
                .Where(s => s.CourseId == courseId)
                .Include(s => s.Lessons)
                .OrderByDescending(s => s.DisplayOrder)
                .ToListAsync();
        }

        public async Task<Section?> GetWithCourseAsync(Guid sectionId)
        {
            return await _context.Sections
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.Id == sectionId);
        }
    }
}

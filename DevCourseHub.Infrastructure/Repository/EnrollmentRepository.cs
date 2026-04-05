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
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(AppDbContext context) : base(context)
        {
        }
        public IQueryable<Enrollment> GetUserEnrollmentAsync(Guid userId)
        {
            return _context.Enrollments
                .Include(e => e.Course)
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.EnrolledAt);
        }

        public async Task<bool> IsUserEnrolledAsync(Guid userId, Guid courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e => e.UserId == userId && e.CourseId == courseId);
        }
    }
}

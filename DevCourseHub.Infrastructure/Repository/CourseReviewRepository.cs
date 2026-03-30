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
    public class CourseReviewRepository : GenericRepository<CourseReview>, ICourseReviewRepository
    {
        public CourseReviewRepository(AppDbContext context) : base(context)
        {
        }
        public IQueryable<CourseReview> GetByCourseIdQueryable(Guid courseId)
        {
            return _context.CourseReviews.Where(cr => cr.CourseId == courseId).Include(x => x.User);
        }

        public async Task<CourseReview?> GetByUserAndCourseAsync(Guid userId, Guid courseId)
        {
            return await _context.CourseReviews.FirstOrDefaultAsync(cr => cr.UserId == userId && cr.CourseId == courseId);
        }
    }
}

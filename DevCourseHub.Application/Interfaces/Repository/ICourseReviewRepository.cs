using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface ICourseReviewRepository : IGenericRepository<CourseReview>
    {
        IQueryable<CourseReview> GetByCourseIdQueryable(Guid courseId);
        Task<CourseReview?> GetByUserAndCourseAsync(Guid userId, Guid courseId);
    }
}

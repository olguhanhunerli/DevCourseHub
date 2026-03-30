using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        IQueryable<Course> GetPublishedCoursesQueryable();
        IQueryable<Course> GetAllCoursesQueryable();
        IQueryable<Course> GetCourseByInstructorQueryable(Guid instructorId);
        Task<Course?> GetCourseDetailAsync(Guid id);
        Task<Course?> GetCourseWithInstructorAsync(Guid id);
    }
}

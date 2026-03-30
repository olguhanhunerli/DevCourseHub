using DevCourseHub.Application.DTOs.Common;
using DevCourseHub.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface ICourseService
    {
        Task<PagedResultDto<CourseDto>> GetAllPublishedAsync(GetCourseQueryDto query);
        Task<PagedResultDto<CourseDto>> GetAllForAdminAsync(GetCourseQueryDto query);
        Task<PagedResultDto<CourseDto>> GetMyCoursesAsync(GetCourseQueryDto query);
        Task<CourseDetailDto?> GetByIdAsync(Guid id);
        Task<CourseDetailDto?> CreateAsync(CreateCourseDto request);
        Task<CourseDetailDto?> UpdateAsync(Guid id, UpdateCourseDto request);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> PublishedAsync(Guid id);
    }
}

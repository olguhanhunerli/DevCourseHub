using DevCourseHub.Application.DTOs.Common;
using DevCourseHub.Application.DTOs.Course;
using DevCourseHub.Application.DTOs.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> EnrollAsync(Guid courseId);
        Task<PagedResultDto<EnrollmentDto>> GetMyCourseAsync(GetEnrollmentQueryDto query);
    }
}

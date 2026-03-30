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
        Task<IEnumerable<EnrollmentDto>> GetMyCourseAsync();
    }
}

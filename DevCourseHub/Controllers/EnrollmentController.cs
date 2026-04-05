using DevCourseHub.Application.DTOs.Course;
using DevCourseHub.Application.DTOs.Enrollment;
using DevCourseHub.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevCourseHub.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("courses/{courseId}/enroll")]
        [Authorize(Roles = "Student,Instructor,Admin")]
        public async Task<IActionResult> Enroll(Guid courseId)
        {
            var enrollment = await _enrollmentService.EnrollAsync(courseId);
            return Ok(enrollment);
        }
        [HttpGet("enrollments/my-courses")]
        [Authorize]
        public async Task<IActionResult> GetMyCourses([FromQuery] GetEnrollmentQueryDto query)
        {
            var enrollments = await _enrollmentService.GetMyCourseAsync(query);
            return Ok(enrollments);
        }
    }
}

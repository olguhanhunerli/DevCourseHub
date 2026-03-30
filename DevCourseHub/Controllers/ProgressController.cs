using DevCourseHub.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevCourseHub.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }
        [HttpPost("lessons/{lessonId:guid}/complete")]
        [Authorize]
        public async Task<IActionResult> CompleteLesson(Guid lessonId)
        {
            var result = await _progressService.CompleteLessonAsync(lessonId);
            return Ok(result);
        }
        [HttpPost("lessons/{lessonId:guid}/incomplete")]
        [Authorize]
        public async Task<IActionResult> IncompleteLesson(Guid lessonId)
        {
            var result = await _progressService.MarkLessonInCompleteAsync(lessonId);
            return Ok(result);
        }
        [HttpGet("progress/courses/{courseId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetCourseProgress(Guid courseId)
        {
            var result = await _progressService.GetCourseProgressAsync(courseId);
            return Ok(result);
        }
    }
}

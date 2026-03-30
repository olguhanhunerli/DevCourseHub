using DevCourseHub.Application.DTOs.Lesson;
using DevCourseHub.Application.DTOs.Section;
using DevCourseHub.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevCourseHub.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost("sections/{sectionId:guid}/lessons")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> CreateLesson(Guid sectionId, [FromBody] CreateLessonDto createLessonDto)
        {
            var createdLesson = await _lessonService.CreateLessonAsync(sectionId, createLessonDto);
            return Ok(createdLesson);
        }
        [HttpPut("lessons/{lessonId:guid}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> UpdateLesson(Guid lessonId, [FromBody] UpdateLessonDto updateLessonDto)
        {
            var updatedLesson = await _lessonService.UpdateLessonAsync(lessonId, updateLessonDto);
            if (updatedLesson == null) return NotFound();
            return Ok(updatedLesson);
        }
        [HttpDelete("lessons/{lessonId:guid}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteLesson(Guid lessonId)
        {
            var result = await _lessonService.DeleteLessonAsync(lessonId);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpGet("sections/{sectionId:guid}/lessons")]
        [Authorize]
        public async Task<IActionResult> GetLessonById(Guid sectionId)
        {
            var lessons = await _lessonService.GetLessonByIdAsync(sectionId);
            return Ok(lessons);
        }
    }
}

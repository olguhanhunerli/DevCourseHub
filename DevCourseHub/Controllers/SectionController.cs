using DevCourseHub.Application.DTOs.Section;
using DevCourseHub.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevCourseHub.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        [HttpPost("courses/{courseId:guid}/sections")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> CreateSection(Guid courseId, [FromBody] CreateSectionDto createSectionDto)
        {
            var createdSection = await _sectionService.CreateAsync(courseId, createSectionDto);
            return Ok(createdSection);
        }
        [HttpPut("sections/{sectionId:guid}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> UpdateSection(Guid sectionId, [FromBody] UpdateSectionDto updateSectionDto)
        {
            var updatedSection = await _sectionService.UpdateAsync(sectionId, updateSectionDto);
            if (updatedSection == null) return NotFound();
            return Ok(updatedSection);
        }
        [HttpDelete("sections/{sectionId:guid}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteSection(Guid sectionId)
        {
            var result = await _sectionService.DeleteAsync(sectionId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

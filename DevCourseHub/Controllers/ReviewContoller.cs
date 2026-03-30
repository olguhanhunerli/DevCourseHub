using DevCourseHub.Application.DTOs.Review;
using DevCourseHub.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevCourseHub.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ReviewContoller: ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewContoller(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("courses/{courseId:guid}/reviews")]
        [Authorize]
        public async Task<IActionResult> Create(Guid courseId, [FromBody] CreateReviewDto request)
        {
           var result = await _reviewService.CreateAsync(courseId, request);
            return Ok(result);
        }

        [HttpPut("courses/{courseId:guid}/reviews")]
        [Authorize]
        public async Task<IActionResult> Update(Guid courseId, [FromBody] UpdateReviewDto request)
        {
            var result = await _reviewService.UpdateAsync(courseId, request);
            return Ok(result);
        }
        [HttpGet("courses/{courseId:guid}/reviews")]
        [Authorize]
        public async Task<IActionResult> GetByCourseId(Guid courseId, [FromQuery] GetCourseReviewsQueryDto query)
        {
            var result = await _reviewService.GetByCourseIdAsync(courseId, query);
            return Ok(result);
        }
    }
}

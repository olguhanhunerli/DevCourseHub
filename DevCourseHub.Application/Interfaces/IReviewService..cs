using DevCourseHub.Application.DTOs.Common;
using DevCourseHub.Application.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> CreateAsync(Guid courseId, CreateReviewDto createReviewDto);
        Task<ReviewDto> UpdateAsync(Guid courseId, UpdateReviewDto createReviewDto);
        Task<PagedResultDto<ReviewDto>> GetByCourseIdAsync(Guid courseId, GetCourseReviewsQueryDto query);
    }
}

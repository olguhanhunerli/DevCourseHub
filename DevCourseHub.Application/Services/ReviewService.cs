using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevCourseHub.Application.DTOs.Common;
using DevCourseHub.Application.DTOs.Review;
using DevCourseHub.Application.Interfaces;
using DevCourseHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ReviewDto> CreateAsync(Guid courseId, CreateReviewDto createReviewDto)
        {
            var userId = _currentUserService.UserId;
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Kullanıcı doğrulanamadı.");
            }
            if (createReviewDto.Rating < 1 || createReviewDto.Rating > 5)
            {
                throw new ArgumentException("Rating değeri 1 ile 5 arasında olmalıdır.");
            }

            var isEnrolled = await _unitOfWork.Enrollments.AnyAsync(e => e.CourseId == courseId && e.UserId == userId);
            if (!isEnrolled)
                throw new Exception("Bu kursa kayıtlı değilsiniz, yorum yapamazsınız.");

            var existingReview = await _unitOfWork.CourseReviews.GetByUserAndCourseAsync(userId.Value, courseId);

            if (existingReview != null)
            {
                throw new Exception("Bu kursa zaten bir yorum yaptınız, güncellemek istiyorsanız mevcut yorumunuzu güncelleyebilirsiniz.");
            }
            var review = new CourseReview
            {
                CourseId = courseId,
                UserId = userId.Value,
                Rating = createReviewDto.Rating,
                Comment = createReviewDto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.CourseReviews.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<PagedResultDto<ReviewDto>> GetByCourseIdAsync(Guid courseId, GetCourseReviewsQueryDto query)
        {
            var reviewsQuery = _unitOfWork.CourseReviews.GetByCourseIdQueryable(courseId);

            if(query.Rating.HasValue)
            {
                reviewsQuery = reviewsQuery.Where(r => r.Rating == query.Rating.Value);
            }

            reviewsQuery = query.SortBy.ToLower() switch
            {
                "oldest" => reviewsQuery.OrderBy(x => x.CreatedAt),
                "highest" => reviewsQuery.OrderByDescending(x => x.Rating),
                "lowest" => reviewsQuery.OrderBy(x => x.Rating),
                _ => reviewsQuery.OrderByDescending(x => x.CreatedAt)
            };

            var totalCount = await reviewsQuery.CountAsync();

            var pageNumber = query.PageNumber < 1 ? 1 : query.PageNumber;
            var pageSize = query.PageSize < 1 ? 10 : query.PageSize;

            var items = await reviewsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResultDto<ReviewDto> {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<ReviewDto> UpdateAsync(Guid courseId, UpdateReviewDto createReviewDto)
        {
            var userId = _currentUserService.UserId;
            if (userId is null)
            {
                throw new UnauthorizedAccessException("Kullanıcı doğrulanamadı.");
            }
            if (createReviewDto.Rating < 1 || createReviewDto.Rating > 5)
            {
                throw new ArgumentException("Rating değeri 1 ile 5 arasında olmalıdır.");
            }

            var review = await _unitOfWork.CourseReviews.GetByUserAndCourseAsync(userId.Value, courseId);
            if (review == null)
            {
                throw new Exception("Bu kursa henüz yorum yapmadınız, düzenleme yapmak istiyorsanız önce bir yorum oluşturmalısınız.");
            }

            review.Rating = createReviewDto.Rating;
            review.Comment = createReviewDto.Comment;
            review.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CourseReviews.Update(review);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ReviewDto>(review);
        }
    }
}


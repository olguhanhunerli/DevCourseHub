using AutoMapper;
using DevCourseHub.Application.DTOs.Progress;
using DevCourseHub.Application.Interfaces;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Services
{
    public class ProgressService : IProgressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public ProgressService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<LessonProgressDto> CompleteLessonAsync(Guid lessonId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                throw new Exception("Kullanıcı Doğrulanamadı.");
            }

            var lesson = await _unitOfWork.Lessons.GetWithSectionAndCourseAsync(lessonId);
            if (lesson == null)
            {
                throw new Exception("Ders bulunamadı.");
            }

            var courseId = lesson.Section.CourseId;

            var isEnrolled = await _unitOfWork.Enrollments.IsUserEnrolledAsync(userId.Value, courseId);
            if (!isEnrolled)
            {
                throw new Exception("Kullanıcı bu kursa kayıtlı değil.");
            }

            var progress = await _unitOfWork.LessonsProgress.GetByUserAndLessonAsync(userId.Value, lessonId);
            if (progress is null)
            {
                progress = new Domain.Entities.LessonProgress
                {
                    UserId = userId.Value,
                    LessonId = lessonId,
                    IsCompleted = true,
                    CompletedAt = DateTime.UtcNow
                };

                await _unitOfWork.LessonsProgress.AddAsync(progress);
            }
            else
            {
                progress.IsCompleted = true;
                progress.CompletedAt = DateTime.UtcNow;
                _unitOfWork.LessonsProgress.Update(progress);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LessonProgressDto>(progress);
        }

        public async Task<CourseProgressDto> GetCourseProgressAsync(Guid courseId)
        {
            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                throw new Exception("Kullanıcı Doğrulanamadı.");
            }

            var course = await _unitOfWork.Courses.GetCourseDetailAsync(courseId);
            if (course == null)
            {
                throw new Exception("Kurs bulunamadı.");
            }

            var isEnrolled = await _unitOfWork.Enrollments.IsUserEnrolledAsync(userId.Value, courseId);
            if (!isEnrolled)
            {
                throw new Exception("Kullanıcı bu kursa kayıtlı değil.");
            }

            var totalLessons = course.Sections.SelectMany(s => s.Lessons).Count();

            var progress = await _unitOfWork.LessonsProgress.GetByUserAndCourseAsync(userId.Value, courseId);

            var completedLessons = progress.Count(p => p.IsCompleted);

            var percentage = totalLessons == 0 ? 0 : (double)completedLessons / totalLessons * 100;

            return new CourseProgressDto
            {
                CourseId = courseId,
                TotalLessons = totalLessons,
                CompletedLessons = completedLessons,
                Percentage = Math.Round(percentage, 2),
                Lessons = progress.Select(x => new LessonProgressDto
                {
                    LessonId = x.LessonId,
                    IsCompleted = x.IsCompleted,
                    CompletedAt = x.CompletedAt
                }).ToList()
            };

        }

        public async Task<LessonProgressDto> MarkLessonInCompleteAsync(Guid lessonId)
        {
            var userId = _currentUserService.UserId;

            if (userId is null)
                throw new Exception("Kullanıcı doğrulanamadı.");

            var progress = await _unitOfWork.LessonsProgress
                .GetByUserAndLessonAsync(userId.Value, lessonId);

            if (progress is null)
                throw new Exception("Bu ders için progress bulunamadı.");

            progress.IsCompleted = false;
            progress.CompletedAt = null;

            _unitOfWork.LessonsProgress.Update(progress);
            await _unitOfWork.SaveChangesAsync();

            return new LessonProgressDto
            {
                LessonId = lessonId,
                IsCompleted = false,
                CompletedAt = null
            };
        }
    }
}

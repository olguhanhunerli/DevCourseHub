using AutoMapper;
using DevCourseHub.Application.DTOs.Lesson;
using DevCourseHub.Application.Interfaces;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<LessonDto> CreateLessonAsync(Guid sectionId, CreateLessonDto createLessonDto)
        {
            var section = await _unitOfWork.Sections.GetByIdAsync(sectionId);
            if (section == null)
            {
                return null;
            }

            EnsureCourseOwnerShip(section.Course);

            var newLesson = new Lesson
            {
                Id = Guid.NewGuid(),
                Title = createLessonDto.Title,
                Content = createLessonDto.Content,
                VideoUrl = createLessonDto.VideoUrl,
                DisplayOrder = createLessonDto.DisplayOrder,
                DurationInMinutes = createLessonDto.DurationInMinutes,
                IsPreview = createLessonDto.IsPreview,
                SectionId = sectionId
            };

            await _unitOfWork.Lessons.AddAsync(newLesson);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LessonDto>(newLesson);
        }

        public async Task<bool> DeleteLessonAsync(Guid lessonId)
        {
            var lesson = await _unitOfWork.Lessons.GetByIdAsync(lessonId);
            if (lesson == null)
            {
                return false;
            }
            EnsureCourseOwnerShip(lesson.Section.Course);
            _unitOfWork.Lessons.Remove(lesson);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<LessonDto?> GetLessonByIdAsync(Guid lessonId)
        {
            var lesson = await _unitOfWork.Lessons.GetByIdAsync(lessonId);
            if (lesson == null)
            {
                return null;
            }
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<LessonDto?> UpdateLessonAsync(Guid lessonId, UpdateLessonDto updateLessonDto)
        {
            var lesson = await _unitOfWork.Lessons.GetByIdAsync(lessonId);
            if (lesson == null)
            {
                return null;
            }

            EnsureCourseOwnerShip(lesson.Section.Course);

            lesson.Title = updateLessonDto.Title;
            lesson.Content = updateLessonDto.Content;
            lesson.VideoUrl = updateLessonDto.VideoUrl;
            lesson.DisplayOrder = updateLessonDto.DisplayOrder;
            lesson.DurationInMinutes = updateLessonDto.DurationInMinutes;
            lesson.IsPreview = updateLessonDto.IsPreview;

            _unitOfWork.Lessons.Update(lesson);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LessonDto>(lesson);

        }

        public void EnsureCourseOwnerShip(Course course)
        {
            var currentUserId = _currentUserService.UserId;
            var currentRole = _currentUserService.Role;

            if (currentRole == "Admin")
            {
                return;
            }
            if (currentRole == "Instructor" && currentUserId == course.InstructorId)
            {
                return;
            }
            throw new UnauthorizedAccessException("Bu kurs üzerinde işlem yapma yetkiniz yok.");
        }
    }
}

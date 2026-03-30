using AutoMapper;
using DevCourseHub.Application.DTOs.Section;
using DevCourseHub.Application.Interfaces;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Services
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public SectionService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<SectionDto> CreateAsync(Guid courseId, CreateSectionDto createSectionDto)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new ArgumentException("Böyle bir kurs bulunamadı.");
            }

            EnsureCourseOwnerShip(course);

            var newSection = new Section
            {
                Title = createSectionDto.Title,
                DisplayOrder = createSectionDto.DisplayOrder,
                CourseId = courseId
            };

            await _unitOfWork.Sections.AddAsync(newSection);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<SectionDto>(newSection);
        }

        public async Task<bool> DeleteAsync(Guid sectionId)
        {
            var section = await _unitOfWork.Sections.GetByIdAsync(sectionId);
            if (section == null)
            {
                return false;
            }
            EnsureCourseOwnerShip(section.Course);
            _unitOfWork.Sections.Remove(section);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<SectionDto> UpdateAsync(Guid sectionId, UpdateSectionDto updateSectionDto)
        {
            var section = await _unitOfWork.Sections.GetByIdAsync(sectionId);
            if (section == null)
            {
                return null;
            }

            EnsureCourseOwnerShip(section.Course);

            section.Title = updateSectionDto.Title;
            section.DisplayOrder = updateSectionDto.DisplayOrder;

            _unitOfWork.Sections.Update(section);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SectionDto>(section);
        }

        public void EnsureCourseOwnerShip(Course course)
        {
            var currentUserId = _currentUserService.UserId;
            var currentRole = _currentUserService.Role;
            if (currentRole == "Admin")
                return;
            if (currentRole == "Instructor" && course.InstructorId == currentUserId)
                return;
            throw new UnauthorizedAccessException("Bu kurs üzerinde işlem yapma yetkiniz yoktur.");
        }
    }
}

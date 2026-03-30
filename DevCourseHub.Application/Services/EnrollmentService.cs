using AutoMapper;
using DevCourseHub.Application.DTOs.Enrollment;
using DevCourseHub.Application.Interfaces;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<EnrollmentDto> EnrollAsync(Guid courseId)
        {
            var currentUserId = _currentUserService.UserId;
            if (currentUserId is null)
            {
                throw new Exception("Kullanıcı doğrulanamadı.");
            }
            var course = await _unitOfWork.Courses.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new Exception("Kurs bulunamadı.");
            }

            if (!course.IsPublished)
            {
                throw new Exception("Yayınlanmamış kursa kayıt yapılamaz.");
            }

            var isAlreadyEnrolled = await _unitOfWork.Enrollments.IsUserEnrolledAsync(currentUserId.Value, courseId);

            if (isAlreadyEnrolled)
                throw new Exception("Bu kursa zaten kayıtlısınız.");

            var newEnrollment = new Enrollment
            {
                CourseId = courseId,
                UserId = currentUserId.Value,
                EnrolledAt = DateTime.UtcNow
            };

            await _unitOfWork.Enrollments.AddAsync(newEnrollment);
            await _unitOfWork.SaveChangesAsync();

            newEnrollment.Course = course;

            return _mapper.Map<EnrollmentDto>(newEnrollment);
        }

        public async Task<IEnumerable<EnrollmentDto>> GetMyCourseAsync()
        {
            var currentUserId = _currentUserService.UserId;
            if (currentUserId is null)
            {
                throw new Exception("Kullanıcı doğrulanamadı.");
            }

            var enrollments = await _unitOfWork.Enrollments.GetUserEnrollmentAsync(currentUserId.Value);
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }
    }
}

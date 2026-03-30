using AutoMapper;
using DevCourseHub.Application.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Mappings
{
    public class CourseReviewProfile: Profile
    {
        public CourseReviewProfile()
        {
            CreateMap<Domain.Entities.CourseReview, ReviewDto>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}

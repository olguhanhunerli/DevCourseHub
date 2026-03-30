using AutoMapper;
using DevCourseHub.Application.DTOs.Progress;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Mappings
{
    public class ProgressProfile : Profile
    {
        public ProgressProfile()
        {
            CreateMap<LessonProgress, LessonProgressDto>();
        }
    }
}

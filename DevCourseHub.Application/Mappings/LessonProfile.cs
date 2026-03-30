using AutoMapper;
using DevCourseHub.Application.DTOs.Lesson;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Mappings
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();
        }
    }
}

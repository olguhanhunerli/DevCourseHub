using AutoMapper;
using DevCourseHub.Application.DTOs.Section;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Mappings
{
    public class SectionProfile: Profile
    {
        public SectionProfile() { 
            CreateMap<Section, SectionDto>()
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons));
        }
    }
}

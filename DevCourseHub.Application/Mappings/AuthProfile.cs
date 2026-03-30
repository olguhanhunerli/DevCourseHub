using AutoMapper;
using DevCourseHub.Application.DTOs.Auth;
using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Mappings
{
    public class AuthProfile: Profile
    {
        public AuthProfile() {
            CreateMap<User, CurrentUserDto>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Auth
{
    public class CurrentUserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}

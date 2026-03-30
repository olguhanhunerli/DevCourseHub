using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        (string Token, DateTime Expiration) GenerateToken(User user);
    }
}

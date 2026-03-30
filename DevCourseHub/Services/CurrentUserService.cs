using DevCourseHub.Application.Interfaces;
using System.Security.Claims;

namespace DevCourseHub.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Guid? UserId
        {
            get
            {
                var userIdClaim = _accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(userIdClaim, out var userId))
                {
                    return userId;
                }

                return null;
            }
        }

        public string? Role => _accessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
    }
}

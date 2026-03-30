using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}

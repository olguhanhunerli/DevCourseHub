using DevCourseHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces.Repository
{
    public interface ISectionRepository: IGenericRepository<Section>
    {
        Task<Section?> GetWithCourseAsync(Guid sectionId);
        Task<IEnumerable<Section>> GetByCourseIdAsync(Guid courseId);
    }
}

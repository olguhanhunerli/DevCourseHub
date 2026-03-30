using DevCourseHub.Application.DTOs.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.Interfaces
{
    public interface ISectionService
    {
        Task<SectionDto> CreateAsync(Guid courseId, CreateSectionDto createSectionDto);
        Task<SectionDto> UpdateAsync(Guid sectionId, UpdateSectionDto updateSectionDto);
        Task<bool> DeleteAsync(Guid sectionId);
    }
}

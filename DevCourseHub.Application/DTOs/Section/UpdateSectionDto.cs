using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Section
{
    public class UpdateSectionDto
    {
        public string Title { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}

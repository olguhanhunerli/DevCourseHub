using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Enrollment
{
    public class GetEnrollmentQueryDto
    {
        public string? Search { get; set; }
        public string? Category { get; set; }
        public string? Level { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

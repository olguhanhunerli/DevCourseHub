using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Course
{
    public class GetCourseQueryDto
    {
        public string? Search { get; set; }
        public string? Category { get; set; }
        public string? Level { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

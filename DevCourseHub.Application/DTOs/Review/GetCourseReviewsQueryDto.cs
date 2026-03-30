using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Review
{
    public class GetCourseReviewsQueryDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int?  Rating { get; set; }
        public string? SortBy { get; set; } = "newest"; // newest, oldest, highest, lowest
    }
}

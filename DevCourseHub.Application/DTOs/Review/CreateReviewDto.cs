using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCourseHub.Application.DTOs.Review
{
    public class CreateReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}

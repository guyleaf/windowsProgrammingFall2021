using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSelectionApp.Models.Dto
{
    public class CourseSelectionDataDto
    {
        public CourseSelectionDataDto(Course course, bool isCourseSelected = false)
        {
            IsCourseSelected = isCourseSelected;
            Course = course;
        }

        public bool IsCourseSelected
        {
            get; set;
        }

        public Course Course
        {
            get; private set;
        }
    }
}

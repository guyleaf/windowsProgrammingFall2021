using System.Collections.Generic;

namespace CourseSelectionApp.Models
{
    public class Curriculum
    {
        public Class Class
        {
            get; set;
        }

        public IList<Course> Courses
        {
            get; set;
        }
    }
}

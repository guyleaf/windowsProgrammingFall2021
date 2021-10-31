using System.Collections.Generic;
using System.Linq;

using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models
{
    public class Curriculum
    {
        public Curriculum(IList<Course> courses, Class classInfo)
        {
            Courses = courses;
            Class = classInfo;
        }

        public Class Class
        {
            get;
        }

        public IList<Course> Courses
        {
            get;
        }
    }
}

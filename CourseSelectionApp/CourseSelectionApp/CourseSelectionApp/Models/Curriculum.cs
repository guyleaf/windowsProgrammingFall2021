using System.Collections.Generic;
using System.ComponentModel;

using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models
{
    public class Curriculum
    {
        public Curriculum(IList<Course> courses, Class classInfo)
        {
            Courses = new BindingList<Course>(courses);
            Class = classInfo;
        }

        public Class Class
        {
            get;
        }

        public BindingList<Course> Courses
        {
            get;
        }
    }
}

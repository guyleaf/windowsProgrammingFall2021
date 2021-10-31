using System.Collections.Generic;

using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models
{
    public class Class
    {
        public string DepartmentName 
        { 
            get; set;
        }

        public string Name 
        { 
            get; set; 
        }

        public string CoursesUri 
        { 
            get; set; 
        }

        public HashSet<Course> CourseSet 
        { 
            get; set; 
        }
    }
}

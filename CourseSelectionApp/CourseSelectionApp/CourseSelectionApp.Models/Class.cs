using System.Collections.Generic;

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

        public HashSet<string> CourseIdList 
        { 
            get; set; 
        }
    }
}

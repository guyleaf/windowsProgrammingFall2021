using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models.Dto
{
    public class CourseListItem
    {
        public CourseListItem(Course course)
        {
            Course = course;
        }

        public Course Course
        {
            get;
        }

        public string CourseName
        {
            get
            {
                return Course.Info.Name;
            }
        }
    }
}

namespace CourseSelectionApp.Models
{
    public class Course
    {
        public string Id
        {
            get; set;
        }

        public CourseInfo Info 
        { 
            get; set; 
        }

        public CourseSelectionInfo SelectionInfo 
        { 
            get; set; 
        }

        public CourseTime ClassTime 
        { 
            get; set; 
        }

        public CourseStatus Status 
        { 
            get; set; 
        }

        public CourseOtherInfo OtherInfo
        { 
            get; set; 
        }
    }
}
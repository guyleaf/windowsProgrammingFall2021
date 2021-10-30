namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseInfo
    {
        public string Name 
        { 
            get; set; 
        }

        public string Stage 
        { 
            get; set; 
        }

        public string Teacher 
        { 
            get; set; 
        }

        public string ClassRoom 
        { 
            get; set; 
        }

        // TODO: Use Enum
        public string RequiredOrElectiveCourse
        { 
            get; set; 
        }

        public string TeachingAssistant 
        { 
            get; set; 
        }
    }
}

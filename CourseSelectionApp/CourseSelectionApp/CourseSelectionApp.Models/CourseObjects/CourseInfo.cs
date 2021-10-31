namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseInfo
    {
        public CourseInfo()
        {
            Name = string.Empty;
            Stage = string.Empty;
            Teacher = string.Empty;
            ClassRoom = string.Empty;
            RequiredOrElectiveCourse = string.Empty;
            TeachingAssistant = string.Empty;
        }

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

        /// <summary>
        /// 複製 CourseInfo 資料
        /// </summary>
        /// <returns></returns>
        public CourseInfo Clone()
        {
            var courseInfo = new CourseInfo()
            {
                Name = Name,
                Stage = Stage,
                Teacher = Teacher,
                ClassRoom = ClassRoom,
                RequiredOrElectiveCourse = RequiredOrElectiveCourse,
                TeachingAssistant = TeachingAssistant
            };

            return courseInfo;
        }
    }
}

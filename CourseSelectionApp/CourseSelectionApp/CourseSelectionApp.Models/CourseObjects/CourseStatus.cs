namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseStatus
    {
        public CourseStatus()
        {
            NumberOfDropStudents = string.Empty;
            NumberOfStudents = string.Empty;
        }

        public string NumberOfStudents 
        { 
            get; set; 
        }

        public string NumberOfDropStudents 
        { 
            get; set; 
        }

        /// <summary>
        /// 複製 CourseStatus 資料
        /// </summary>
        /// <returns></returns>
        public CourseStatus Clone()
        {
            var courseStatus = new CourseStatus()
            {
                NumberOfStudents = NumberOfStudents,
                NumberOfDropStudents = NumberOfDropStudents
            };

            return courseStatus;
        }
    }
}

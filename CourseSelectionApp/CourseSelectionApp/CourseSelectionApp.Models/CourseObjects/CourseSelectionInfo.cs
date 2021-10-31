namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseSelectionInfo
    {
        public CourseSelectionInfo()
        {
            Credits = string.Empty;
            Hours = string.Empty;
        }

        public string Credits 
        { 
            get; set; 
        }

        public string Hours 
        { 
            get; set; 
        }

        /// <summary>
        /// 複製 CourseSelectionInfo 資料
        /// </summary>
        /// <returns></returns>
        public CourseSelectionInfo Clone()
        {
            var courseSelectionInfo = new CourseSelectionInfo()
            {
                Credits = Credits,
                Hours = Hours
            };

            return courseSelectionInfo;
        }
    }
}

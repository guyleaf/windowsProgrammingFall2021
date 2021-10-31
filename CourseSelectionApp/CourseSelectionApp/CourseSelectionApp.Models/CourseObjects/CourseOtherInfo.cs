namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseOtherInfo
    {
        public CourseOtherInfo()
        {
            Language = string.Empty;
            Syllabus = string.Empty;
            Note = string.Empty;
            Audit = string.Empty;
            Experiment = string.Empty;
        }

        public string Language 
        { 
            get; set; 
        }

        public string Syllabus 
        { 
            get; set; 
        }

        public string Note 
        { 
            get; set; 
        }

        public string Audit 
        { 
            get; set; 
        }

        public string Experiment 
        { 
            get; set; 
        }

        /// <summary>
        /// 複製 CourseOtherInfo 資料
        /// </summary>
        /// <returns></returns>
        public CourseOtherInfo Clone()
        {
            var courseOtherInfo = new CourseOtherInfo()
            {
                Language = Language,
                Syllabus = Syllabus,
                Note = Note,
                Audit = Audit,
                Experiment = Experiment
            };

            return courseOtherInfo;
        }
    }
}

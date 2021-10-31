using System.Collections.Generic;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseTime
    {
        public CourseTime()
        {
            Sunday = new List<string>();
            Monday = new List<string>();
            Tuesday = new List<string>();
            Wednesday = new List<string>();
            Thursday = new List<string>();
            Friday = new List<string>();
            Saturday = new List<string>();
        }

        public IList<string> Sunday 
        { 
            get; set; 
        }

        public IList<string> Monday 
        { 
            get; set;
        }

        public IList<string> Tuesday 
        { 
            get; set; 
        }

        public IList<string> Wednesday 
        { 
            get; set; 
        }

        public IList<string> Thursday 
        { 
            get; set; 
        }

        public IList<string> Friday 
        { 
            get; set; 
        }

        public IList<string> Saturday 
        { 
            get; set; 
        }

        /// <summary>
        /// 複製 CourseTime 資料
        /// </summary>
        /// <returns></returns>
        public CourseTime Clone()
        {
            var courseTime = new CourseTime()
            {
                Sunday = new List<string>(Sunday),
                Monday = new List<string>(Sunday),
                Tuesday = new List<string>(Sunday),
                Wednesday = new List<string>(Sunday),
                Thursday = new List<string>(Sunday),
                Friday = new List<string>(Sunday),
                Saturday = new List<string>(Sunday)
            };

            return courseTime;
        }
    }
}

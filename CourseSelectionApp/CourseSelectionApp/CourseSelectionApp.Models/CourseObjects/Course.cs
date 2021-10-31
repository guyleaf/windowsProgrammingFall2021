using System;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class Course : IEquatable<Course>
    {
        public Course()
        {
            Id = string.Empty;
            Info = new CourseInfo();
            SelectionInfo = new CourseSelectionInfo();
            CourseTime = new CourseTime();
            Status = new CourseStatus();
            OtherInfo = new CourseOtherInfo();
        }

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

        public CourseTime CourseTime 
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

        /// <summary>
        /// 比較物件 Id
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Course other)
        {
            //CheckSelectedCourses whether the compared object is null.
            if (other == null)
            {
                return false;
            }

            //CheckSelectedCourses whether the compared object references the same data.
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id;
        }

        /// <summary>
        /// 取得 Id 雜湊值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// 覆寫 Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return Equals(other as Course);
        }

        /// <summary>
        /// 複製 Course 資料
        /// </summary>
        /// <returns></returns>
        public Course Clone()
        {
            var course = new Course()
            {
                Id = Id,
                Info = Info.Clone(),
                SelectionInfo = SelectionInfo.Clone(),
                Status = Status.Clone(),
                CourseTime = CourseTime.Clone(),
                OtherInfo = OtherInfo.Clone()
            };

            return course;
        }
    }
}
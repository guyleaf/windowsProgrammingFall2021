using System;

namespace CourseSelectionApp.Models
{
    public class Course : IEquatable<Course>
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
    }
}
using System;

namespace CourseSelectionApp.Models.Dto
{
    public class CourseTimeRow : IEquatable<CourseTimeRow>
    {

        public CourseTimeRow(int index)
        {
            Index = index;
            Sunday = Monday = Tuesday = Wednesday = Thursday = Friday = Saturday = false;
        }

        public CourseTimeRow(CourseTimeRow other)
        {
            Index = other.Index;
            Sunday = other.Sunday;
            Monday = other.Monday;
            Tuesday = other.Tuesday;
            Wednesday = other.Wednesday;
            Thursday = other.Thursday;
            Friday = other.Friday;
            Saturday = other.Saturday;
        }

        public int Index
        {
            get; set;
        }

        public bool Sunday
        {
            get; set;
        }

        public bool Monday
        {
            get; set;
        }

        public bool Tuesday
        {
            get; set;
        }

        public bool Wednesday
        {
            get; set;
        }

        public bool Thursday
        {
            get; set;
        }

        public bool Friday
        {
            get; set;
        }

        public bool Saturday
        {
            get; set;
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseTimeRow other)
        {
            // check whether the compared object is null.
            if (other == null)
            {
                return false;
            }

            // check whether the compared object references the same data.
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return IsSameCourseTimeRow(other); 
        }

        /// <summary>
        /// 取得 Index 雜湊值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        /// <summary>
        /// 是否為相同 CourseTimeRow
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsSameCourseTimeRow(CourseTimeRow other)
        {
            return Index.Equals(other.Index)
                && Sunday.Equals(other.Sunday)
                && Monday.Equals(other.Monday)
                && Tuesday.Equals(other.Tuesday)
                && Wednesday.Equals(other.Wednesday)
                && Thursday.Equals(other.Thursday)
                && Friday.Equals(other.Friday)
                && Saturday.Equals(other.Saturday);
        }
    }
}

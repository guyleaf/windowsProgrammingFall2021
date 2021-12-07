using System;

using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models.Dto
{
    public class CourseWithActivateAndClass : IEquatable<CourseWithActivateAndClass>
    {
        private const string DEFAULT_TEXT_FOR_COURSE_ACTIVATE_OR_NOT = "開課";

        public CourseWithActivateAndClass(Course course, Class classInfo)
        {
            ActivateOrNot = DEFAULT_TEXT_FOR_COURSE_ACTIVATE_OR_NOT;
            Course = course;
            Class = classInfo;
        }

        public CourseWithActivateAndClass(CourseWithActivateAndClass courseWithActivateAndClass)
        {
            ActivateOrNot = courseWithActivateAndClass.ActivateOrNot;
            Course = new Course(courseWithActivateAndClass.Course);
            Class = courseWithActivateAndClass.Class;
        }

        public string ActivateOrNot
        {
            get; set;
        }

        public Course Course
        {
            get;
        }

        public Class Class
        {
            get; set;
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseWithActivateAndClass other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Class.Equals(other.Class)
                && ActivateOrNot.Equals(other.ActivateOrNot)
                && Course.Equals(other.Course);
        }

        /// <summary>
        /// 取得雜湊值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Class.GetHashCode() ^ ActivateOrNot.GetHashCode() ^ Course.GetHashCode();
        }
    }
}
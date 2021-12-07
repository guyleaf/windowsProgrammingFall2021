using System;

namespace CourseSelectionApp.Models.Dto
{
    public class CourseListItem : IEquatable<CourseListItem>
    {
        public CourseListItem(CourseWithActivateAndClass courseWithActivateAndClass)
        {
            CourseWithActivateAndClass = courseWithActivateAndClass;
        }

        public CourseWithActivateAndClass CourseWithActivateAndClass
        {
            get;
        }

        public string CourseName
        {
            get
            {
                return CourseWithActivateAndClass.Course.Info.Name;
            }
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseListItem other)
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

            return CourseWithActivateAndClass.Equals(other.CourseWithActivateAndClass);
        }

        /// <summary>
        /// 取得 CourseWithActivateAndClass 雜湊值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return CourseWithActivateAndClass.GetHashCode();
        }
    }
}

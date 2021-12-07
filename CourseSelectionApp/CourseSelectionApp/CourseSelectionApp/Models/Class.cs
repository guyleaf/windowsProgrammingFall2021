using System;
using System.Collections.Generic;

using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models
{
    public class Class : IEquatable<Class> 
    {
        public string DepartmentName 
        { 
            get; set;
        }

        public string Name 
        { 
            get; set; 
        }

        public string CoursesUri 
        { 
            get; set; 
        }

        public HashSet<Course> CourseSet 
        { 
            get; set; 
        }

        /// <summary>
        /// 比較 Class
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Class other)
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

            return Name.Equals(other.Name) && DepartmentName.Equals(other.DepartmentName);
        }

        /// <summary>
        /// 取得 Name 雜湊值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

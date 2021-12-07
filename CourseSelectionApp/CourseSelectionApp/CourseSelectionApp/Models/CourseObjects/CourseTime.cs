using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseTime : IEquatable<CourseTime>
    {
        public CourseTime()
        {
            Sunday = new BindingList<string>();
            Monday = new BindingList<string>();
            Tuesday = new BindingList<string>();
            Wednesday = new BindingList<string>();
            Thursday = new BindingList<string>();
            Friday = new BindingList<string>();
            Saturday = new BindingList<string>();
        }

        public CourseTime(CourseTime courseTime)
        {
            Sunday = new BindingList<string>(courseTime.Sunday);
            Monday = new BindingList<string>(courseTime.Monday);
            Tuesday = new BindingList<string>(courseTime.Tuesday);
            Wednesday = new BindingList<string>(courseTime.Wednesday);
            Thursday = new BindingList<string>(courseTime.Thursday);
            Friday = new BindingList<string>(courseTime.Friday);
            Saturday = new BindingList<string>(courseTime.Saturday);
        }

        public BindingList<string> Sunday 
        { 
            get;
        }

        public BindingList<string> Monday 
        { 
            get;
        }

        public BindingList<string> Tuesday 
        { 
            get;
        }

        public BindingList<string> Wednesday 
        { 
            get;
        }

        public BindingList<string> Thursday 
        { 
            get;
        }

        public BindingList<string> Friday 
        { 
            get;
        }

        public BindingList<string> Saturday 
        { 
            get;
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseTime other)
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

            return IsSameCourseTime(other);
        }

        /// <summary>
        /// 是否為相同 CourseTime
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsSameCourseTime(CourseTime other)
        {
            return EqualsTime(Sunday, other.Sunday) &&
                EqualsTime(Monday, other.Monday) &&
                EqualsTime(Tuesday, other.Tuesday) &&
                EqualsTime(Wednesday, other.Wednesday) &&
                EqualsTime(Thursday, other.Thursday) &&
                EqualsTime(Friday, other.Friday) &&
                EqualsTime(Saturday, other.Saturday);
        }

        /// <summary>
        /// 比較時間
        /// </summary>
        /// <param name="leftProperty"></param>
        /// <param name="rightProperty"></param>
        /// <returns></returns>
        private bool EqualsTime(BindingList<string> leftProperty, BindingList<string> rightProperty)
        {
            return !leftProperty.Except(rightProperty).Any();
        }
    }
}

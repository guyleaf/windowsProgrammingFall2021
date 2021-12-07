using System;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseStatus : NotifyPropertyChangedModel, IEquatable<CourseStatus>
    {
        private string _numberOfStudents;
        private string _numberOfDropStudents;

        public CourseStatus()
        {
            _numberOfStudents = string.Empty;
            _numberOfDropStudents = string.Empty;
        }

        public CourseStatus(CourseStatus courseStatus)
        {
            _numberOfStudents = courseStatus.NumberOfStudents;
            _numberOfDropStudents = courseStatus.NumberOfDropStudents;
        }

        public string NumberOfStudents 
        { 
            get
            {
                return _numberOfStudents;
            }
            set
            {
                _numberOfStudents = value;
                NotifyOnPropertyChanged(nameof(NumberOfStudents));
            }
        }

        public string NumberOfDropStudents 
        {
            get
            {
                return _numberOfDropStudents;
            }
            set
            {
                _numberOfDropStudents = value;
                NotifyOnPropertyChanged(nameof(NumberOfDropStudents));
            }
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseStatus other)
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

            return _numberOfStudents.Equals(other.NumberOfStudents)
                && _numberOfDropStudents.Equals(other.NumberOfDropStudents);
        }
    }
}

using System;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseSelectionInfo : NotifyPropertyChangedModel, IEquatable<CourseSelectionInfo>
    {
        private const string DEFAULT_VALUE_FOR_HOURS = "1";
        private string _credits;
        private string _hours;

        public CourseSelectionInfo()
        {
            _credits = string.Empty;
            _hours = DEFAULT_VALUE_FOR_HOURS;
        }

        public CourseSelectionInfo(CourseSelectionInfo selectionInfo)
        {
            _credits = selectionInfo.Credits;
            _hours = selectionInfo.Hours;
        }

        public string Credits 
        { 
            get
            {
                return _credits;
            }
            set
            {
                _credits = value;
                NotifyOnPropertyChanged(nameof(Credits));
            }
        }

        public string Hours 
        { 
            get
            {
                return _hours;
            }
            set
            {
                _hours = value;
                NotifyOnPropertyChanged(nameof(Hours));
            }
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseSelectionInfo other)
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

            return _credits.Equals(other.Credits) &&
                _hours.Equals(other.Hours);
        }
    }
}

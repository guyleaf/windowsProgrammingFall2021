using System;
using System.ComponentModel;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseInfo : NotifyPropertyChangedModel, IEquatable<CourseInfo>
    {
        private const string DEFAULT_VALUE_FOR_REQUIRED_OR_ELECTIVE_COURSE = "○";
        private string _name;
        private string _stage;
        private string _teacher;
        private string _classRoom;
        private string _requiredOrElectiveCourse;
        private string _teachingAssistant;

        public CourseInfo()
        {
            _name = string.Empty;
            _stage = string.Empty;
            _teacher = string.Empty;
            _classRoom = string.Empty;
            _requiredOrElectiveCourse = DEFAULT_VALUE_FOR_REQUIRED_OR_ELECTIVE_COURSE;
            _teachingAssistant = string.Empty;
        }

        public CourseInfo(CourseInfo courseInfo)
        {
            _name = courseInfo.Name;
            _stage = courseInfo.Stage;
            _teacher = courseInfo.Teacher;
            _classRoom = courseInfo.ClassRoom;
            _requiredOrElectiveCourse = courseInfo.RequiredOrElectiveCourse;
            _teachingAssistant = courseInfo.TeachingAssistant;
        }

        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOnPropertyChanged(nameof(Name));
            }
        }

        public string Stage 
        {
            get
            {
                return _stage;
            }
            set
            {
                _stage = value;
                NotifyOnPropertyChanged(nameof(Stage));
            }
        }

        public string Teacher 
        { 
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
                NotifyOnPropertyChanged(nameof(Teacher));
            }
        }

        public string ClassRoom
        {
            get
            {
                return _classRoom;
            }
            set
            {
                _classRoom = value;
                NotifyOnPropertyChanged(nameof(ClassRoom));
            }
        }

        // TODO: Use Enum
        public string RequiredOrElectiveCourse
        { 
            get
            {
                return _requiredOrElectiveCourse;
            }
            set
            {
                _requiredOrElectiveCourse = value;
                NotifyOnPropertyChanged(nameof(RequiredOrElectiveCourse));
            }
        }

        public string TeachingAssistant 
        { 
            get
            {
                return _teachingAssistant;
            }
            set
            {
                _teachingAssistant = value;
                NotifyOnPropertyChanged(nameof(TeachingAssistant));
            }
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseInfo other)
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

            return IsSameCourseInfo(other);
        }

        /// <summary>
        /// 是否為相同 CourseInfo
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsSameCourseInfo(CourseInfo other)
        {
            return _name.Equals(other.Name)
                && _stage.Equals(other.Stage)
                && _teacher.Equals(other.Teacher)
                && _classRoom.Equals(other.ClassRoom)
                && _requiredOrElectiveCourse.Equals(other.RequiredOrElectiveCourse)
                && _teachingAssistant.Equals(other.TeachingAssistant);
        }
    }
}

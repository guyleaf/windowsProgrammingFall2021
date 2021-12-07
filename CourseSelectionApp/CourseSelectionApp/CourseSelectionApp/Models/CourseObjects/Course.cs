using System;
using System.ComponentModel;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class Course : NotifyPropertyChangedModel, IEquatable<Course>
    {
        private string _id;
        private CourseInfo _courseInfo;
        private CourseSelectionInfo _selectionInfo;
        private CourseTime _courseTime;
        private CourseStatus _status;
        private CourseOtherInfo _otherInfo;

        public Course()
        {
            _id = string.Empty;
            _courseInfo = new CourseInfo();
            _selectionInfo = new CourseSelectionInfo();
            _courseTime = new CourseTime();
            _status = new CourseStatus();
            _otherInfo = new CourseOtherInfo();
        }

        public Course(Course course)
        {
            _id = course.Id;
            _courseInfo = new CourseInfo(course.Info);
            _selectionInfo = new CourseSelectionInfo(course.SelectionInfo);
            _courseTime = new CourseTime(course.CourseTime);
            _status = new CourseStatus(course.Status);
            _otherInfo = new CourseOtherInfo(course.OtherInfo);
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyOnPropertyChanged(nameof(Id));
            }
        }

        public CourseInfo Info 
        {
            get
            {
                return _courseInfo;
            }
            set
            {
                _courseInfo = value;
                NotifyOnPropertyChanged(nameof(Info));
            }
        }

        public CourseSelectionInfo SelectionInfo 
        {
            get
            {
                return _selectionInfo;
            }
            set
            {
                _selectionInfo = value;
                NotifyOnPropertyChanged(nameof(SelectionInfo));
            }
        }

        public CourseTime CourseTime 
        { 
            get
            {
                return _courseTime;
            }
            set
            {
                _courseTime = value;
                NotifyOnPropertyChanged(nameof(CourseTime));
            }
        }

        public CourseStatus Status 
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyOnPropertyChanged(nameof(Status));
            }
        }

        public CourseOtherInfo OtherInfo
        { 
            get
            {
                return _otherInfo;
            }
            set
            {
                _otherInfo = value;
                NotifyOnPropertyChanged(nameof(OtherInfo));
            }
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Course other)
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

            return IsSameCourse(other);
        }

        /// <summary>
        /// 取得 Id 雜湊值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        /// <summary>
        /// 是否為相同課程
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsSameCourse(Course other)
        {
            return _id.Equals(other.Id)
                && _courseInfo.Equals(other.Info)
                && _selectionInfo.Equals(other.SelectionInfo)
                && _courseTime.Equals(other.CourseTime)
                && _status.Equals(other.Status)
                && _otherInfo.Equals(other.OtherInfo);
        }
    }
}
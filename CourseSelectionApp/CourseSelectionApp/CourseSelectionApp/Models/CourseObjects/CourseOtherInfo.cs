using System;

namespace CourseSelectionApp.Models.CourseObjects
{
    public class CourseOtherInfo : NotifyPropertyChangedModel, IEquatable<CourseOtherInfo>
    {
        private string _language;
        private string _syllabus;
        private string _note;
        private string _audit;
        private string _experiment;

        public CourseOtherInfo()
        {
            _language = string.Empty;
            _syllabus = string.Empty;
            _note = string.Empty;
            _audit = string.Empty;
            _experiment = string.Empty;
        }

        public CourseOtherInfo(CourseOtherInfo otherInfo)
        {
            _language = otherInfo.Language;
            _syllabus = otherInfo.Syllabus;
            _note = otherInfo.Note;
            _audit = otherInfo.Audit;
            _experiment = otherInfo.Experiment;
        }

        public string Language 
        { 
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                NotifyOnPropertyChanged(nameof(Language));
            }
        }

        public string Syllabus 
        {
            get
            {
                return _syllabus;
            }
            set
            {
                _syllabus = value;
                NotifyOnPropertyChanged(nameof(Syllabus));
            }
        }

        public string Note 
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                NotifyOnPropertyChanged(nameof(Note));
            }
        }

        public string Audit 
        {
            get
            {
                return _audit;
            }
            set
            {
                _audit = value;
                NotifyOnPropertyChanged(nameof(Audit));
            }
        }

        public string Experiment 
        {
            get
            {
                return _experiment;
            }
            set
            {
                _experiment = value;
                NotifyOnPropertyChanged(nameof(Experiment));
            }
        }

        /// <summary>
        /// 比較物件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CourseOtherInfo other)
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

            return _language.Equals(other.Language)
                && _syllabus.Equals(other.Syllabus)
                && _note.Equals(other.Note)
                && _audit.Equals(other.Audit)
                && _experiment.Equals(other.Experiment);
        }
    }
}

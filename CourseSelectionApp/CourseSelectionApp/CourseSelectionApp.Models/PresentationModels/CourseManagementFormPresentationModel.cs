using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

using CourseSelectionApp.Models.CourseObjects;

namespace CourseSelectionApp.Models.PresentationModels
{
    public class CourseManagementFormPresentationModel : NotifyPropertyChangedModel, IDataErrorInfo
    {
        private const string TEXT_FOR_SAVE_BUTTON = "存檔";
        private const string TEXT_FOR_CREATE_BUTTON = "新增";
        private const string ERROR_MESSAGES_SEPARATOR = "\n";
        private const string ERROR_MESSAGE_FOR_COURSE_ID = "課號需必為數字。";
        private const string ERROR_MESSAGE_FOR_REQUIRED = "不得為空。";
        private readonly Regex _validationRuleForCourseId;
        private readonly Regex _validationRuleForRequeired;

        private string _selectedCourseId;
        private Course _currentCourse;
        private readonly IDictionary<string, string> _errorMessages;
        private bool _isNewCourse;

        public CourseManagementFormPresentationModel()
        {
            _selectedCourseId = null;
            _currentCourse = null;
            _errorMessages = new Dictionary<string, string>();
            _isNewCourse = false;

            _validationRuleForCourseId = new Regex(@"^[0-9]+$");
            _validationRuleForRequeired = new Regex(@"^.+$");
        }

        public bool IsCourseExisted
        {
            get
            {
                return _currentCourse != null;
            }
        }

        public string CreateOrSaveButtonText
        {
            get
            {
                return _isNewCourse ? TEXT_FOR_CREATE_BUTTON : TEXT_FOR_SAVE_BUTTON;
            }
        }

        public string CourseId
        {
            get
            {
                return IsCourseExisted ? _currentCourse.Id : string.Empty;
            }
            set
            {
                _currentCourse.Id = value;
                ValidateCourseId();
            }
        }

        public string CourseName
        {
            get
            {
                return IsCourseExisted ? _currentCourse.Info.Name : string.Empty;
            }
            set
            {
                _currentCourse.Info.Name = value;
                ValidateCourseName();
            }
        }

        public string CourseStage
        {
            get
            {
                return IsCourseExisted ? _currentCourse.Info.Stage : string.Empty;
            }
            set
            {
                _currentCourse.Info.Stage = value;
                ValidateCourseStage();
            }
        }

        /// <summary>
        /// 編輯課程
        /// </summary>
        /// <param name="course"></param>
        public void EditCourse(Course course)
        {
            _selectedCourseId = course.Id;
            _currentCourse = course.Clone();
            _isNewCourse = false;
            NotifyOnPropertyChanged(null);
        }

        /// <summary>
        /// 創建課程
        /// </summary>
        public void CreateCourse()
        {
            _selectedCourseId = null;
            _currentCourse = new Course();
            _isNewCourse = true;
            NotifyOnPropertyChanged(null);
        }

        public bool IsDataValid
        {
            get
            {
                return IsCourseExisted && _errorMessages.Count == 0;
            }
        }

        public string Error
        {
            get
            {
                return string.Join(ERROR_MESSAGES_SEPARATOR, _errorMessages);
            }
        }

        public string this[string propertyName]
        {
            get
            {
                _errorMessages.TryGetValue(propertyName, out var message);
                return message;
            }
        }

        /// <summary>
        /// 驗證 course id
        /// </summary>
        private void ValidateCourseId()
        {
            Validate(nameof(CourseId), _validationRuleForCourseId.IsMatch(CourseId), ERROR_MESSAGE_FOR_COURSE_ID);
        }

        /// <summary>
        /// 驗證 course name
        /// </summary>
        private void ValidateCourseName()
        {
            Validate(nameof(CourseName), _validationRuleForRequeired.IsMatch(CourseName), ERROR_MESSAGE_FOR_REQUIRED);
        }

        /// <summary>
        /// 驗證 course stage
        /// </summary>
        private void ValidateCourseStage()
        {
            Validate(nameof(CourseStage), _validationRuleForRequeired.IsMatch(CourseStage), ERROR_MESSAGE_FOR_REQUIRED);
        }

        /// <summary>
        /// 驗證資料
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="isValid"></param>
        /// <param name="errorMessage"></param>
        private void Validate(string propertyName, bool isValid, string errorMessage)
        {
            if (isValid)
            {
                if (_errorMessages.ContainsKey(propertyName))
                {
                    _errorMessages.Remove(propertyName);
                    NotifyOnPropertyChanged(nameof(IsDataValid));
                }
            }
            else if (!_errorMessages.ContainsKey(propertyName))
            {
                _errorMessages.Add(propertyName, errorMessage);
                NotifyOnPropertyChanged(nameof(IsDataValid));
            }
        }
    }
}

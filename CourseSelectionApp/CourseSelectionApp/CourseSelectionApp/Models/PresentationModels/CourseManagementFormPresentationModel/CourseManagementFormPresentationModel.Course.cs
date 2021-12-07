using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace CourseSelectionApp.Models.PresentationModels
{
    partial class CourseManagementFormPresentationModel : IDataErrorInfo
    {
        private const string RULE_FOR_NUMBER = @"^([0-9]+[.])?[0-9]+$";
        private const string TEXT_FOR_SAVE_BUTTON = "存檔";
        private const string TEXT_FOR_CREATE_BUTTON = "新增";
        private const string TEXT_FOR_EDIT_GROUP_BOX = "編輯課程";
        private const string TEXT_FOR_NEW_GROUP_BOX = "新增課程";
        private const string ERROR_MESSAGES_SEPARATOR = "\n";
        private const string ERROR_MESSAGE_FOR_NUMBER = "必為數字。";
        private const string ERROR_MESSAGE_FOR_REQUIRED = "不得為空。";
        private readonly Regex _regexRuleForNumber;

        private bool IsCourseModified
        {
            get
            {
                return !_currentCourse.Equals(_selectedCourse);
            }
        }

        public bool IsCreateOrSaveButtonEnabled
        {
            get
            {
                return IsCourseSelectedOrCreated
                    && (IsCourseModified || IsCourseTimeGridModified)
                    && !_errorMessages.Any();
            }
        }

        public bool IsCourseSelectedOrCreated
        {
            get
            {
                return _selectedCourse != null || _editMode == Enums.CourseEditMode.New;
            }
        }

        public bool IsNewCourseButtonEnabled
        {
            get
            {
                return _editMode != Enums.CourseEditMode.New;
            }
        }

        public string CourseActivateOrNot
        {
            get
            {
                return _currentCourse.ActivateOrNot;
            }
            set
            {
                _currentCourse.ActivateOrNot = value;
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CreateOrSaveButtonText
        {
            get
            {
                return _editMode == Enums.CourseEditMode.New ? TEXT_FOR_CREATE_BUTTON : TEXT_FOR_SAVE_BUTTON;
            }
        }

        public string GroupBoxText
        {
            get
            {
                return _editMode == Enums.CourseEditMode.New ? TEXT_FOR_NEW_GROUP_BOX : TEXT_FOR_EDIT_GROUP_BOX;
            }
        }

        public string CourseId
        {
            get
            {
                return _currentCourse.Course.Id;
            }
            set
            {
                _currentCourse.Course.Id = value;
                CheckPropertyForNumber(CourseId, nameof(CourseId));
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseName
        {
            get
            {
                return _currentCourse.Course.Info.Name;
            }
            set
            {
                _currentCourse.Course.Info.Name = value;
                CheckPropertyForRequired(CourseName, nameof(CourseName));
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseStage
        {
            get
            {
                return _currentCourse.Course.Info.Stage;
            }
            set
            {
                _currentCourse.Course.Info.Stage = value;
                CheckPropertyForNumber(CourseStage, nameof(CourseStage));
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseCredits
        {
            get
            {
                return _currentCourse.Course.SelectionInfo.Credits;
            }
            set
            {
                _currentCourse.Course.SelectionInfo.Credits = value;
                CheckPropertyForNumber(CourseCredits, nameof(CourseCredits));
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseTeacher
        {
            get
            {
                return _currentCourse.Course.Info.Teacher;
            }
            set
            {
                _currentCourse.Course.Info.Teacher = value;
                CheckPropertyForRequired(CourseTeacher, nameof(CourseTeacher));
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseRequiredOrElective
        {
            get
            {
                return _currentCourse.Course.Info.RequiredOrElectiveCourse;
            }
            set
            {
                _currentCourse.Course.Info.RequiredOrElectiveCourse = value;
                CheckPropertyForRequired(CourseRequiredOrElective, nameof(CourseRequiredOrElective));
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseTeachingAssistant
        {
            get
            {
                return _currentCourse.Course.Info.TeachingAssistant;
            }
            set
            {
                _currentCourse.Course.Info.TeachingAssistant = value;
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseLanguage
        {
            get
            {
                return _currentCourse.Course.OtherInfo.Language;
            }
            set
            {
                _currentCourse.Course.OtherInfo.Language = value;
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseNote
        {
            get
            {
                return _currentCourse.Course.OtherInfo.Note;
            }
            set
            {
                _currentCourse.Course.OtherInfo.Note = value;
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public string CourseHours
        {
            get
            {
                return _currentCourse.Course.SelectionInfo.Hours;
            }
            set
            {
                _currentCourse.Course.SelectionInfo.Hours = value;
                CheckPropertyForNumber(CourseHours, nameof(CourseHours));
                CheckCourseTimeGrid();
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        public Class Class
        {
            get
            {
                return _currentCourse.Class;
            }
            set
            {
                _currentCourse.Class = value;
                NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
            }
        }

        /// <summary>
        /// 驗證數字
        /// </summary>
        private void CheckPropertyForNumber(string value, string propertyName)
        {
            CheckIsValid(propertyName, _regexRuleForNumber.IsMatch(value), ERROR_MESSAGE_FOR_NUMBER);
        }

        /// <summary>
        /// 驗證必填
        /// </summary>
        private void CheckPropertyForRequired(string value, string propertyName)
        {
            CheckIsValid(propertyName, !string.IsNullOrWhiteSpace(value), ERROR_MESSAGE_FOR_REQUIRED);
        }

        /// <summary>
        /// 驗證所有課程屬性
        /// </summary>
        private void CheckCourseProperties()
        {
            CheckPropertyForNumber(CourseId, nameof(CourseId));
            CheckPropertyForRequired(CourseName, nameof(CourseName));
            CheckPropertyForNumber(CourseStage, nameof(CourseStage));
            CheckPropertyForNumber(CourseCredits, nameof(CourseCredits));
            CheckPropertyForRequired(CourseTeacher, nameof(CourseTeacher));
            CheckPropertyForRequired(CourseRequiredOrElective, nameof(CourseRequiredOrElective));
            CheckPropertyForNumber(CourseHours, nameof(CourseHours));
            CheckCourseTimeGrid();

            NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
        }

        /// <summary>
        /// 驗證資料
        /// </summary>
        private void CheckIsValid(string propertyName, bool isValid, string errorMessage)
        {
            if (_editMode == Enums.CourseEditMode.None)
            {
                return;
            }

            if (isValid)
            {
                _errorMessages.Remove(propertyName);
            }
            else if (!_errorMessages.ContainsKey(propertyName))
            {
                _errorMessages.Add(propertyName, errorMessage);
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
    }
}

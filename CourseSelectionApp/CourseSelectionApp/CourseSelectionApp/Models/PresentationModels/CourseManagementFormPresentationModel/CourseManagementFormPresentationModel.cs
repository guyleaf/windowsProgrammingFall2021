using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

using CourseSelectionApp.Models.CourseObjects;
using CourseSelectionApp.Models.Dto;
using CourseSelectionApp.Models.Enums;

namespace CourseSelectionApp.Models.PresentationModels
{
    public partial class CourseManagementFormPresentationModel : NotifyPropertyChangedModel
    {
        private const string ERROR_MESSAGE_FOR_COURSE_TIME_GRID = "不等於開課時數。";
        private const int NUMBER_OF_ROWS_FOR_COURSE_TIME_GRID = 9;
        private readonly CourseManagementModel _courseManagementModel;
        private readonly IDictionary<string, string> _errorMessages;
        private readonly IList<CourseTimeRow> _selectedCourseTimeGrid;
        private readonly BindingList<CourseTimeRow> _currentCourseTimeGrid;
        private CourseWithActivateAndClass _selectedCourse;
        private CourseWithActivateAndClass _currentCourse;
        private CourseEditMode _editMode;

        private bool IsCourseTimeGridModified
        {
            get
            {
                return _currentCourseTimeGrid.Except(_selectedCourseTimeGrid).Any();
            }
        }

        public CourseEditMode EditMode
        {
            get
            {
                return _editMode;
            }
        }

        public CourseManagementFormPresentationModel(CourseManagementModel courseManagementModel)
        {
            _selectedCourseTimeGrid = new List<CourseTimeRow>();
            _currentCourseTimeGrid = new BindingList<CourseTimeRow>();
            _errorMessages = new Dictionary<string, string>();
            _editMode = CourseEditMode.None;
            _courseManagementModel = courseManagementModel;
            InitializeCurrentDefaultCourse();
            InitializeCourseTimeGrid();

            _regexRuleForNumber = new Regex(RULE_FOR_NUMBER);
        }

        public IBindingList CourseTimeGrid
        {
            get
            {
                return _currentCourseTimeGrid;
            }
        }

        /// <summary>
        /// 初始化 CourseTimeGrid
        /// </summary>
        private void InitializeCourseTimeGrid()
        {
            _currentCourseTimeGrid.Clear();
            for (var i = 1; i <= NUMBER_OF_ROWS_FOR_COURSE_TIME_GRID; i++)
            {
                _currentCourseTimeGrid.Add(new CourseTimeRow(i));
            }
        }

        /// <summary>
        /// 複製 CurrentCourseTimeGrid 至 SelectedCourseTimeGrid
        /// </summary>
        private void CopyCurrentCourseTimeGridToSelectedCourseTimeGrid()
        {
            _selectedCourseTimeGrid.Clear();
            foreach (var row in _currentCourseTimeGrid)
            {
                _selectedCourseTimeGrid.Add(new CourseTimeRow(row));
            }
        }

        /// <summary>
        /// 初始化 _currentCourse
        /// </summary>
        private void InitializeCurrentDefaultCourse()
        {
            // Fake data for the first load
            _currentCourse = new CourseWithActivateAndClass(new Course(), null)
            {
                ActivateOrNot = string.Empty
            };
            var course = _currentCourse.Course;
            course.SelectionInfo.Hours = string.Empty;
            course.Info.RequiredOrElectiveCourse = string.Empty;
        }

        /// <summary>
        /// 轉換 CourseTime 至 _currentCourseTimeGrid
        /// </summary>
        /// <param name="courseTime"></param>
        private void ConvertCourseTimeToCourseTimeGrid(CourseTime courseTime)
        {
            InitializeCourseTimeGrid();

            var propertiesInfo = courseTime.GetType().GetProperties();
            propertiesInfo.AsParallel()
                .ForAll(propertyInfo =>
                    {
                        var propertyName = propertyInfo.Name;
                        var value = (IList<string>)propertyInfo.GetValue(courseTime);
                        value.AsParallel()
                            .ForAll(sectionNumber =>
                            {
                                var index = int.Parse(sectionNumber) - 1;
                                var row = _currentCourseTimeGrid[index];
                                row.GetType().GetProperty(propertyName).SetValue(row, true);
                            });
                    });
        }

        /// <summary>
        /// 轉換 _currentCourseTimeGrid 至 CourseTime
        /// </summary>
        /// <param name="courseTime"></param>
        /// <returns></returns>
        private CourseTime ConvertCourseTimeGridToCourseTime()
        {
            var courseTime = new CourseTime();
            var courseTimeType = courseTime.GetType();
            var indexPropertyName = nameof(CourseTimeRow.Index);
            _currentCourseTimeGrid.AsParallel()
                .ForAll(row =>
                {
                    var propertiesInfo = row.GetType().GetProperties();
                    propertiesInfo.AsParallel()
                        .Where(propertyInfo => propertyInfo.Name != indexPropertyName && (bool)propertyInfo.GetValue(row))
                        .ForAll(propertyInfo =>
                        {
                            var propertyName = propertyInfo.Name;
                            var weekDayList = (IList<string>)courseTimeType.GetProperty(propertyName).GetValue(courseTime);
                            weekDayList.Add(row.Index.ToString());
                        });
                });
            return courseTime;
        }

        /// <summary>
        /// 更新 CourseTimeGrid Status
        /// </summary>
        public void UpdateCourseTimeGridStatus()
        {
            CheckCourseTimeGrid();
            NotifyOnPropertyChanged(nameof(IsCreateOrSaveButtonEnabled));
        }

        /// <summary>
        /// 檢查 _currentCourseTimeGrid
        /// </summary>
        private void CheckCourseTimeGrid()
        {
            if (!string.IsNullOrEmpty(CourseHours))
            {
                var indexPropertyName = nameof(CourseTimeRow.Index);
                var totalTime = _currentCourseTimeGrid.Sum(row =>
                    row.GetType().GetProperties().AsParallel()
                        .Where(propertyInfo => propertyInfo.Name != indexPropertyName)
                        .Sum(propertyInfo => Convert.ToInt32((bool)propertyInfo.GetValue(row))));

                CheckIsValid(nameof(CourseTimeGrid), totalTime.Equals(int.Parse(CourseHours)), ERROR_MESSAGE_FOR_COURSE_TIME_GRID);
            }
        }

        /// <summary>
        /// 編輯課程
        /// </summary>
        public void EditCourse(CourseWithActivateAndClass courseWithActivateAndClass)
        {
            if (courseWithActivateAndClass != null && courseWithActivateAndClass != _selectedCourse)
            {
                _selectedCourse = courseWithActivateAndClass;
                _currentCourse = new CourseWithActivateAndClass(courseWithActivateAndClass);
                ConvertCourseTimeToCourseTimeGrid(_currentCourse.Course.CourseTime);
                CopyCurrentCourseTimeGridToSelectedCourseTimeGrid();
                _editMode = CourseEditMode.Edit;
                CheckCourseProperties();
            }
        }

        /// <summary>
        /// 創建課程
        /// </summary>
        public void CreateNewCourse()
        {
            _selectedCourse = null;
            _currentCourse = new CourseWithActivateAndClass(
                new Course(), _courseManagementModel.GetFirstClass());
            InitializeCourseTimeGrid();
            _editMode = CourseEditMode.New;
            CheckCourseProperties();
        }

        /// <summary>
        /// 新增/存檔
        /// </summary>
        public void ClickCreateOrSaveButton()
        {
            _currentCourse.Course.CourseTime = ConvertCourseTimeGridToCourseTime();
            switch (_editMode)
            {
                case CourseEditMode.New:
                    CreateCourse();
                    _editMode = CourseEditMode.None;
                    break;
                case CourseEditMode.Edit:
                    SaveCourse();
                    break;
                default:
                    throw new NotSupportedException();
            }
            Reset();
        }

        /// <summary>
        /// 新增課程
        /// </summary>
        private void CreateCourse()
        {
            _courseManagementModel.InsertCourse(_currentCourse);
        }

        /// <summary>
        /// 儲存課程
        /// </summary>
        private void SaveCourse()
        {
            _courseManagementModel.UpdateCourse(_currentCourse, _selectedCourse);
        }

        /// <summary>
        /// 重製狀態
        /// </summary>
        private void Reset()
        {
            InitializeCurrentDefaultCourse();
            InitializeCourseTimeGrid();
            _selectedCourse = null;
            _errorMessages.Clear();
            NotifyOnPropertyChanged(null);
        }
    }
}

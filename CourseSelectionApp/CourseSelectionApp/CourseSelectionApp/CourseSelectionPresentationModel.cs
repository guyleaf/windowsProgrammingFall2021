using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;

using CourseSelectionApp.Models.Dto;
using CourseSelectionApp.Services.Interfaces;

namespace CourseSelectionApp
{
    public class CourseSelectionPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICourseService _courseService;
        private IList<CourseSelectionDataDto> _courses;

        public CourseSelectionPresentationModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IList<CourseSelectionDataDto> Courses
        {
            get
            {
                return _courses;
            }
        }

        public bool IsAnyCourseSelected
        {
            get
            {
                return _courses != null && _courses.Any(data => data.IsCourseSelected);
            }
        }

        /// <summary>
        /// 載入課程資料
        /// </summary>
        public void LoadCourses()
        {
            var courses = _courseService.GetAllCourses();
            _courses = courses.Select(course => new CourseSelectionDataDto(course)).ToList();
        }

        /// <summary>
        /// 點選課程
        /// </summary>
        /// <param name="index"></param>
        public void ClickCourseCheckBox()
        {
            Notify(nameof(IsAnyCourseSelected));
        }

        /// <summary>
        /// 通知 Property Update
        /// </summary>
        /// <param name="propertyName"></param>
        private void Notify(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 點擊課程大綱連結
        /// </summary>
        /// <param name="uri"></param>
        internal void ClickCourseSyllabusLink(string uri)
        {
            Process.Start(uri);
        }
    }
}

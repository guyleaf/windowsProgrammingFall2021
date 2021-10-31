using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using CourseSelectionApp.Models.Dto;
using CourseSelectionApp.Models.PresentationModels;

namespace CourseSelectionApp.Models
{
    public class CourseManagementModel : NotifyPropertyChangedModel
    {
        private readonly IList<Class> _classes;
        private readonly BindingList<CourseListItem> _courseList;

        public CourseManagementModel(IList<Class> classes, IList<Curriculum> curriculums)
        {
            _classes = classes;
            var courseList = curriculums
                .AsParallel()
                .SelectMany(curriculum => curriculum.Courses.AsParallel().Select(course => new CourseListItem(course)))
                .ToList();
            _courseList = new BindingList<CourseListItem>(courseList);
        }

        public IBindingList CourseList
        {
            get
            {
                return _courseList;
            }
        }
    }
}

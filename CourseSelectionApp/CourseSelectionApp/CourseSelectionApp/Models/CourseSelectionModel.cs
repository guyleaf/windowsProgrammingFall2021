using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using CourseSelectionApp.Models.CourseObjects;
using CourseSelectionApp.Models.Extensions;
using CourseSelectionApp.Models.PresentationModels;

namespace CourseSelectionApp.Models
{
    public class CourseSelectionModel : NotifyPropertyChangedModel
    {
        private readonly IList<Class> _classes;
        private readonly IDictionary<string, BindingList<Course>> _unselectedCourses;
        private readonly BindingList<Course> _selectedCourses;

        public CourseSelectionModel(IList<Class> classes, IList<Curriculum> curriculums)
        {
            _classes = classes;
            _selectedCourses = new BindingList<Course>();
            _unselectedCourses = new Dictionary<string, BindingList<Course>>();

            curriculums
                .ToList()
                .ForEach(curriculum => _unselectedCourses.Add(curriculum.Class.Name, curriculum.Courses));
        }

        public bool IsAnyCoursesSelected
        {
            get
            {
                return _selectedCourses.Any();
            }
        }

        public IList<string> ClassNames
        {
            get
            {
                return _classes.Select(item => item.Name).ToList();
            }
        }

        public IBindingList SelectedCourses
        {
            get
            {
                return _selectedCourses;
            }
        }

        /// <summary>
        /// 取得未選擇之課程清單
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public IBindingList GetUnselectedCoursesByClassName(string className)
        {
            return _unselectedCourses[className];
        }

        /// <summary>
        /// 取得指定id的未選擇之課程
        /// </summary>
        /// <param name="className"></param>
        /// <param name="courseIdList"></param>
        /// <returns></returns>
        public IList<Course> GetUnselectedCoursesByCourseIdList(string className, params string[] courseIdList)
        {
            return _unselectedCourses[className].AsParallel()
                .Where(course => courseIdList.Contains(course.Id))
                .ToList();
        }

        /// <summary>
        /// 取得該陣列index的未選擇之課程
        /// </summary>
        /// <param name="className"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public Course GetUnselectedCourseByIndex(string className, int index)
        {
            return _unselectedCourses[className][index];
        }

        /// <summary>
        /// 取得該陣列index的未選擇之課程
        /// </summary>
        /// <param name="className"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public Course GetSelectedCourseByIndex(int index)
        {
            return _selectedCourses[index];
        }

        /// <summary>
        /// 選擇清單內所有課程
        /// </summary>
        /// <param name="className"></param>
        /// <param name="indexes"></param>
        public void SelectCourses(string className, IList<string> courseIdList)
        {
            var courses = GetUnselectedCoursesByCourseIdList(className, courseIdList.ToArray());
            _selectedCourses.AddRange(courses);
            _unselectedCourses[className].RemoveRange(courses);

            NotifyOnPropertyChanged(nameof(IsAnyCoursesSelected));
        }

        /// <summary>
        /// 退選課程
        /// </summary>
        /// <param name="courseId"></param>
        public void DropCourse(int rowIndex)
        {
            var course = _selectedCourses[rowIndex];
            _selectedCourses.RemoveAt(rowIndex);

            var className = _classes.First(item => item.CourseSet.Contains(course)).Name;
            _unselectedCourses[className].Add(course);

            NotifyOnPropertyChanged(nameof(IsAnyCoursesSelected));
        }
    }
}

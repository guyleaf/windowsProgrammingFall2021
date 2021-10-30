using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using CourseSelectionApp.Extensions;

namespace CourseSelectionApp.Models
{
    public class CourseSelectionAppModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IList<Curriculum> _curriculums;
        private readonly IDictionary<string, BindingList<Course>> _unselectedCourses;
        private readonly BindingList<Course> _selectedCourses;

        public CourseSelectionAppModel(IList<Curriculum> curriculums)
        {
            _curriculums = curriculums;
            _selectedCourses = new BindingList<Course>();
            _unselectedCourses = new Dictionary<string, BindingList<Course>>();

            _curriculums
                .ToList()
                .ForEach(curriculum => _unselectedCourses.Add(curriculum.Class.Name, new BindingList<Course>(curriculum.Courses)));
        }

        public bool IsAnyCoursesSelected
        {
            get
            {
                return _selectedCourses.Count != 0;
            }
        }

        public IList<string> ClassNames
        {
            get
            {
                return _curriculums.Select(curriculum => curriculum.Class.Name).ToList();
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

            Notify(nameof(IsAnyCoursesSelected));
        }

        /// <summary>
        /// 退選課程
        /// </summary>
        /// <param name="courseId"></param>
        public void DropCourse(int rowIndex)
        {
            var course = _selectedCourses[rowIndex];
            _selectedCourses.RemoveAt(rowIndex);

            var className = _curriculums.First(curriculum => curriculum.Class.CourseIdList.Contains(course.Id)).Class.Name;
            _unselectedCourses[className].Add(course);

            Notify(nameof(IsAnyCoursesSelected));
        }

        /// <summary>
        /// 通知訂閱者
        /// </summary>
        /// <param name="propertyName"></param>
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

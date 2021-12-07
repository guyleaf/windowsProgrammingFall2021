using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using CourseSelectionApp.Models.Dto;

namespace CourseSelectionApp.Models
{
    public class CourseManagementModel : NotifyPropertyChangedModel
    {
        private readonly BindingList<ClassListItem> _classList;
        private readonly BindingList<CourseListItem> _courseList;
        private readonly IList<Curriculum> _curriculums;

        public CourseManagementModel(IList<Class> classes, IList<Curriculum> curriculums)
        {
            _classList = new BindingList<ClassListItem>(classes.Select(classInfo => new ClassListItem(classInfo)).ToList());
            _curriculums = curriculums;
            var courseList = _curriculums
                .AsParallel()
                .SelectMany(
                    curriculum => curriculum.Courses.AsParallel().Select(course => new CourseListItem(new CourseWithActivateAndClass(course, curriculum.Class)))
                )
                .ToList();
            _courseList = new BindingList<CourseListItem>(courseList);
        }

        public IBindingList ClassList
        {
            get
            {
                return _classList;
            }
        }

        public IBindingList CourseList
        {
            get
            {
                return _courseList;
            }
        }

        /// <summary>
        /// 取得第一個班級名稱
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Class GetFirstClass()
        {
            return _classList.First().Class;
        }

        /// <summary>
        /// 更新 Course
        /// </summary>
        /// <param name="newCourse"></param>
        /// <param name="oldCourse"></param>
        public void UpdateCourse(CourseWithActivateAndClass newCourse, CourseWithActivateAndClass oldCourse)
        {
            RemoveClassFromOldCourse(oldCourse);
            RemoveCourseFromOldCurriculum(oldCourse);
            InsertCourseToCurriculum(newCourse);
            int index = _courseList.IndexOf(new CourseListItem(oldCourse));
            _courseList[index] = new CourseListItem(newCourse);
        }

        /// <summary>
        /// 插入 Course
        /// </summary>
        /// <param name="newCourse"></param>
        public void InsertCourse(CourseWithActivateAndClass newCourse)
        {
            InsertCourseToCurriculum(newCourse);
            _courseList.Add(new CourseListItem(newCourse));
        }

        /// <summary>
        /// 插入課程至 Curriculum
        /// </summary>
        /// <param name="newCourse"></param>
        private void InsertCourseToCurriculum(CourseWithActivateAndClass newCourse)
        {
            var newClass = newCourse.Class;
            var curriculum = GetCurriculumByClass(newClass);
            newClass.CourseSet.Add(newCourse.Course);
            curriculum.Courses.Add(newCourse.Course);
        }

        /// <summary>
        /// 從 OldCourse 刪除原本所屬 Class
        /// </summary>
        /// <param name="oldCourse"></param>
        private void RemoveClassFromOldCourse(CourseWithActivateAndClass oldCourse)
        {
            var oldClass = oldCourse.Class;
            oldClass.CourseSet.Remove(oldCourse.Course);
        }

        /// <summary>
        /// 從 OldCourse 刪除原本所屬 Curriculum
        /// </summary>
        /// <param name="oldCourse"></param>
        private void RemoveCourseFromOldCurriculum(CourseWithActivateAndClass oldCourse)
        {
            var oldCurriculum = GetCurriculumByClass(oldCourse.Class);
            oldCurriculum.Courses.Remove(oldCourse.Course);
        }

        /// <summary>
        /// 依據 Class 取得課表
        /// </summary>
        /// <param name="classInfo"></param>
        /// <returns></returns>
        private Curriculum GetCurriculumByClass(Class classInfo)
        {
            return _curriculums.AsParallel().First(curriculum => curriculum.Class.Equals(classInfo));
        }
    }
}

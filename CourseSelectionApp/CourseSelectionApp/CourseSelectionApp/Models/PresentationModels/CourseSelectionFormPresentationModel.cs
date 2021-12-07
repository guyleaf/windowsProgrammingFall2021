using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using CourseSelectionApp.Models.CourseObjects;
using CourseSelectionApp.Models.Enums;

namespace CourseSelectionApp.Models.PresentationModels
{
    public class CourseSelectionFormPresentationModel : NotifyPropertyChangedModel
    {
        private const string FORMATTED_STRING_FOR_COURSE_INFO = "{0}-{1}";
        private readonly CourseSelectionModel _courseSelectionAppModel;
        private readonly IDictionary<string, HashSet<string>> _selectedCourses;

        public CourseSelectionFormPresentationModel(CourseSelectionModel appModel)
        {
            _selectedCourses = new Dictionary<string, HashSet<string>>();
            _courseSelectionAppModel = appModel;

            var classNames = _courseSelectionAppModel.ClassNames;
            // 預設選擇第一個 TabPage
            SelectedTabPage = classNames.First();
            // 初始化 _selectedCourses
            classNames.ToList().ForEach(name => _selectedCourses.Add(name, new HashSet<string>()));
        }

        public bool IsAnyCourseSelected
        {
            get
            {
                return _selectedCourses.Any(pair => pair.Value.Any());
            }
        }

        public string SelectedTabPage
        {
            get; set;
        }

        /// <summary>
        /// 點選課程
        /// </summary>
        /// <param name="index"></param>
        public void ClickCourseCheckBox(int rowIndex)
        {
            var courseId = _courseSelectionAppModel.GetUnselectedCourseByIndex(SelectedTabPage, rowIndex).Id;

            if (_selectedCourses[SelectedTabPage].Contains(courseId))
            {
                _selectedCourses[SelectedTabPage].Remove(courseId);
            }
            else
            {
                _selectedCourses[SelectedTabPage].Add(courseId);
            }

            NotifyOnPropertyChanged(nameof(IsAnyCourseSelected));
        }

        /// <summary>
        /// 點擊課程大綱連結
        /// </summary>
        /// <param name="uri"></param>
        public void ClickCourseSyllabusLink(int rowIndex)
        {
            var course = _courseSelectionAppModel.GetUnselectedCourseByIndex(SelectedTabPage, rowIndex);

            Process.Start(course.OtherInfo.Syllabus);
        }

        /// <summary>
        /// 提交欲加選之課程
        /// </summary>
        public bool TrySubmitSelectedCourses(out IDictionary<SelectionErrorCode, IList<string>> errorList)
        {
            errorList = new Dictionary<SelectionErrorCode, IList<string>>();
            var status = TryCheckSelectedCourses(errorList);
            if (status)
            {
                _selectedCourses.ToList().ForEach(tabCourseIdsDictionary =>
                    _courseSelectionAppModel.SelectCourses(
                        tabCourseIdsDictionary.Key, tabCourseIdsDictionary.Value.ToList()
                    ));
                Reset();
            }
            return status;
        }

        /// <summary>
        /// 重設已選擇之課程清單
        /// </summary>
        private void Reset()
        {
            _selectedCourses
                .AsParallel()
                .ForAll(tabCourseIdsDictionary => tabCourseIdsDictionary.Value.Clear());
            NotifyOnPropertyChanged(nameof(IsAnyCourseSelected));
        }

        /// <summary>
        /// 檢查已選擇之課程
        /// </summary>
        private bool TryCheckSelectedCourses(IDictionary<SelectionErrorCode, IList<string>> errorList)
        {
            var errors = new Dictionary<SelectionErrorCode, IList<Course>>();
            CheckSelectedCourses(errors);
            ConvertErrorsToFormattedStrings(errors, errorList);
            return errors.Count == 0;
        }

        /// <summary>
        /// 檢查已選擇之課程
        /// </summary>
        /// <param name="errors"></param>
        private void CheckSelectedCourses(IDictionary<SelectionErrorCode, IList<Course>> errors)
        {
            // 依據 Id 是否重複分類課程
            var courses = SeparateSelectedCoursesByDuplicatedIdOrNot();
            var existsAnyUniqueCourses = CheckAndTryGetUniqueCourses(courses, SelectionErrorCode.Id, errors, out var uniqueCourses);
            // 依據 Name 是否重複分類課程
            if (existsAnyUniqueCourses)
            {
                courses = SeparateSelectedCoursesByDuplicatedNameOrNot(uniqueCourses);
                existsAnyUniqueCourses = CheckAndTryGetUniqueCourses(courses, SelectionErrorCode.Name, errors, out uniqueCourses);
            }
            // 取得週一至週日的每日衝堂列表
            if (existsAnyUniqueCourses)
            {
                var overlappedCourses = GetOverlappedSelectedCoursesPerWeekDay(uniqueCourses.SelectMany(course => course.Value).ToList());
                CheckOverlappedCoursesExists(overlappedCourses, errors);
            }
        }

        /// <summary>
        /// 檢查並取得合法課程，將不合規則之課程存入 errors
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="errorCode"></param>
        /// <param name="errors"></param>
        /// <param name="uniqueCourses"></param>
        /// <returns></returns>
        private bool CheckAndTryGetUniqueCourses(
            IDictionary<bool, IDictionary<string, IList<Course>>> courses, SelectionErrorCode errorCode, IDictionary<SelectionErrorCode, IList<Course>> errors, out IDictionary<string, IList<Course>> uniqueCourses)
        {
            CheckDuplicatedCoursesExists(courses, errorCode, errors);
            return courses.TryGetValue(false, out uniqueCourses);
        }

        /// <summary>
        /// 轉換錯誤清單至格式化字串
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="errorList"></param>
        private void ConvertErrorsToFormattedStrings(
            IDictionary<SelectionErrorCode, IList<Course>> errors, IDictionary<SelectionErrorCode, IList<string>> errorList)
        {
            foreach (var error in errors)
            {
                errorList.Add(
                    error.Key,
                    error.Value.Select(course => 
                        string.Format(FORMATTED_STRING_FOR_COURSE_INFO, course.Id, course.Info.Name))
                    .ToList()
                );
            }
        }

        /// <summary>
        /// 檢查是否有重複之課程，並加入到 errors 清單中
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="errorCode"></param>
        /// <param name="errors"></param>
        private void CheckDuplicatedCoursesExists(
            IDictionary<bool, IDictionary<string, IList<Course>>> courses, SelectionErrorCode errorCode, IDictionary<SelectionErrorCode, IList<Course>> errors)
        {
            if (courses.TryGetValue(true, out var duplicatedCourses))
            {
                errors.Add(errorCode, duplicatedCourses.Values.SelectMany(course => course).ToList());
            }
        }

        /// <summary>
        /// 檢查衝堂，並加入到 errors 清單中
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="errors"></param>
        private void CheckOverlappedCoursesExists(
            IDictionary<string, IDictionary<string, Course>> coursesForWeek, IDictionary<SelectionErrorCode, IList<Course>> errors)
        {
            var error = coursesForWeek
                .AsParallel()
                .Where(courses => courses.Value.Any())
                .Select(courses => courses.Value)
                .SelectMany(courses => courses.Values)
                .Distinct()
                .ToList();
            if (error.Any())
            {
                errors.Add(SelectionErrorCode.Time, error);
            }
        }

        /// <summary>
        /// 取得已選擇的 course 的資料，依據相同 course Id 分類
        /// </summary>
        /// <returns></returns>
        private IDictionary<bool, IDictionary<string, IList<Course>>> SeparateSelectedCoursesByDuplicatedIdOrNot()
        {
            var courseDictionary = _selectedCourses
                .AsParallel()
                .SelectMany(pair => 
                    _courseSelectionAppModel
                        .GetUnselectedCoursesByCourseIdList(pair.Key, pair.Value.Distinct().ToArray())
                        .AsParallel()
                        .ToDictionary(course => course.Id)
                )
                .GroupBy(pair => pair.Key)
                .ToDictionary<IGrouping<string, KeyValuePair<string, Course>>, string, IList<Course>>(
                    pair => pair.Key,
                    // 重複的課程編號只需要一門課當作錯誤提示
                    pair => pair.Select(pairs => pairs.Value).ToList()
                );
            return SeparateSelectedCoursesByDuplicatedKeyOrNot(courseDictionary);
        }

        /// <summary>
        /// 取得已選擇的 course 的資料，依據相同 course Name 分類
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        private IDictionary<bool, IDictionary<string, IList<Course>>> SeparateSelectedCoursesByDuplicatedNameOrNot(
            IDictionary<string, IList<Course>> courses)
        {
            var courseDictionary = courses.Values
                .AsParallel()
                .SelectMany(course => course)
                .GroupBy(course => course.Info.Name)
                .ToDictionary<IGrouping<string, Course>, string, IList<Course>>(pair => pair.Key, pair => pair.ToList());

            return SeparateSelectedCoursesByDuplicatedKeyOrNot(courseDictionary);
        }

        /// <summary>
        /// 依據 dictionary 的 key 是否重複分類課程
        /// </summary>
        /// <param name="courseDictionary"></param>
        /// <returns>字典，True => 有重複之課程，False => 無重複之課程，如果沒有則為不存在</returns>
        private IDictionary<bool, IDictionary<string, IList<Course>>> SeparateSelectedCoursesByDuplicatedKeyOrNot(
            IDictionary<string, IList<Course>> courseDictionary)
        {
            return courseDictionary.AsParallel()
                .GroupBy(pair => pair.Value.Skip(1).Any())
                .ToDictionary<IGrouping<bool, KeyValuePair<string, IList<Course>>>, bool, IDictionary<string, IList<Course>>>(
                    pair => pair.Key,
                    pair => pair.ToDictionary<KeyValuePair<string, IList<Course>>, string, IList<Course>> (
                        pairs => pairs.Key,
                        pairs => pairs.Value.Distinct().ToList()
                    )
                );
        }

        /// <summary>
        /// 取得週一至週日的每日衝堂列表
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        private IDictionary<string, IDictionary<string, Course>> GetOverlappedSelectedCoursesPerWeekDay(
            IList<Course> courses)
        {
            var weekNames = typeof(CourseTime)
                .GetProperties().Select(property => property.Name);

            return weekNames
                .AsParallel()
                .ToDictionary(
                    week => week,
                    week => GetOverlappedSelectedCoursesInWeekDay(courses, week)
                );
        }

        /// <summary>
        /// 依據參數指定之星期，取得衝堂之課程
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        private IDictionary<string, Course> GetOverlappedSelectedCoursesInWeekDay(
            IList<Course> courses, string week)
        {
            return courses
                .AsParallel()
                .Where(course => courses.AsParallel()
                    .Where(nestedCourse => nestedCourse != course)
                    .Select(nestedCourse =>
                    {
                        return (string[])GetPropertyValue(nestedCourse.CourseTime, week);
                    })
                    .Any(array =>
                    {
                        var hashSet = new HashSet<string>((string[])GetPropertyValue(course.CourseTime, week));
                        return hashSet.Intersect(array).Any();
                    })
                )
                .ToDictionary(course => course.Id);
        }

        /// <summary>
        /// 取得 property value
        /// </summary>
        /// <param name="target"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object GetPropertyValue(object target, string propertyName)
        {
            return target.GetType().GetProperty(propertyName).GetValue(target);
        }
    }
}

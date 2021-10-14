using System.Collections.Generic;

using CourseSelectionApp.Models;

namespace CourseSelectionApp.Readers
{
    public interface ICourseTableReader
    {
        /// <summary>
        /// 取得課程資料
        /// </summary>
        /// <returns></returns>
        IList<Course> GetCourses();
    }
}
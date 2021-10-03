using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseSelectionApp.Models;

namespace CourseSelectionApp.Services.Interfaces
{
    public interface ICourseService
    {
        /// <summary>
        /// 取得所有課程資料
        /// </summary>
        /// <returns></returns>
        IList<Course> GetAllCourses();
    }
}

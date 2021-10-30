using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseSelectionApp.Models;

namespace CourseSelectionApp
{
    public class CourseSelectionResultFormPresentationModel
    {
        private readonly CourseSelectionAppModel _courseSelectionAppModel;

        public CourseSelectionResultFormPresentationModel(CourseSelectionAppModel courseSelectionAppModel)
        {
            _courseSelectionAppModel = courseSelectionAppModel;
        }

        /// <summary>
        /// 點擊課程大綱連結
        /// </summary>
        /// <param name="uri"></param>
        public void ClickCourseSyllabusLink(int rowIndex)
        {
            var course = _courseSelectionAppModel.GetSelectedCourseByIndex(rowIndex);

            Process.Start(course.OtherInfo.Syllabus);
        }
    }
}

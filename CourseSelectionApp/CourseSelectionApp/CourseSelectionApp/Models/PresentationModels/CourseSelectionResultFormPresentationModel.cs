using System.Diagnostics;

namespace CourseSelectionApp.Models.PresentationModels
{
    public class CourseSelectionResultFormPresentationModel
    {
        private readonly CourseSelectionModel _courseSelectionAppModel;

        public CourseSelectionResultFormPresentationModel(CourseSelectionModel courseSelectionAppModel)
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

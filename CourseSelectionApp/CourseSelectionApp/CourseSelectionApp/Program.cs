using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using CourseSelectionApp.Forms;
using CourseSelectionApp.Models;
using CourseSelectionApp.Services;

using HtmlAgilityPack;

namespace CourseSelectionApp
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var courseSelectionAppModel = new CourseSelectionAppModel(LoadCurriculumData());

            var startUpPresentationModel = new StartUpFormPresentationModel();

            Application.Run(new StartUpForm(startUpPresentationModel, courseSelectionAppModel));
        }

        /// <summary>
        /// 載入全部課程
        /// </summary>
        private static IList<Curriculum> LoadCurriculumData()
        {
            var webClient = new HtmlWeb();
            var classCrawlerService = new ClassCrawlerService(webClient);
            var courseCrawlerService = new CourseCrawlerService(webClient);

            const string DEPARTMENT_URI = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-3&year=110&sem=1&code=59";

            // 取得班級資料
            var classes = classCrawlerService.GetResults(new Uri(DEPARTMENT_URI));

            // 取得全部課程
            return classes.Select(classInfo => CollectCourses(courseCrawlerService, classInfo)).ToList();
        }

        /// <summary>
        /// 聚集課程資料
        /// </summary>
        /// <param name="service"></param>
        /// <param name="classInfo"></param>
        /// <returns></returns>
        private static Curriculum CollectCourses(
            CourseCrawlerService service, Class classInfo)
        {
            var result = service.GetResults(new Uri(classInfo.CoursesUri));
            classInfo.CourseIdList = result.Select(course => course.Id).ToHashSet();

            return new Curriculum()
            {
                Class = classInfo,
                Courses = result
            };
        }
    }
}

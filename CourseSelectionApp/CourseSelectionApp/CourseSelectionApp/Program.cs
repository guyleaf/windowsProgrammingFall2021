using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using CourseSelectionApp.Forms;
using CourseSelectionApp.Models;
using CourseSelectionApp.Models.PresentationModels;
using CourseSelectionApp.Services;
using CourseSelectionApp.Commons;

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
            // 載入資料
            const string DEPARTMENT_URI = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-3&year=110&sem=1&code=59";
            var webClient = new HtmlWeb();
            var classes = LoadClassData(webClient, DEPARTMENT_URI);
            var curriculums = LoadCurriculumData(webClient, classes);
            // 初始化 Model
            var courseManagementModel = new CourseManagementModel(classes, curriculums);
            var courseSelectionModel = new CourseSelectionModel(classes, curriculums);
            var startUpPresentationModel = new StartUpFormPresentationModel();
            // 初始化 Commons
            var controlUtils = new ControlCommons();

            Application.Run(new StartUpForm(startUpPresentationModel, courseSelectionModel, courseManagementModel, controlUtils));
        }

        /// <summary>
        /// 載入班級資料
        /// </summary>
        /// <param name="webClient"></param>
        /// <param name="departmentUrl"></param>
        /// <returns></returns>
        private static IList<Class> LoadClassData(HtmlWeb webClient, string departmentUrl)
        {
            var classCrawlerService = new ClassCrawlerService(webClient);
            // 取得班級資料
            var classes = classCrawlerService.GetResults(new Uri(departmentUrl));

            return classes.OrderBy(classInfo => classInfo.Name).ToList();
        }

        /// <summary>
        /// 載入全部課程
        /// </summary>
        /// <param name="webClient"></param>
        /// <param name="classes"></param>
        /// <returns></returns>
        private static IList<Curriculum> LoadCurriculumData(HtmlWeb webClient, IList<Class> classes)
        {
            var courseCrawlerService = new CourseCrawlerService(webClient);
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
            classInfo.CourseSet = result.ToHashSet();

            return new Curriculum(result, classInfo);
        }
    }
}

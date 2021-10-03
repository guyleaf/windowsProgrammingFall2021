using System;
using System.Windows.Forms;

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

            var courseResourceUri = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            var webClient = new HtmlWeb();
            var courseSelectionPresentationModel = new CourseSelectionPresentationModel(new CourseService(webClient, courseResourceUri));
            var form = new CourseSelectionForm(courseSelectionPresentationModel);

            Application.Run(form);
        }
    }
}

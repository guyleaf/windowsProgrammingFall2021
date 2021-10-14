using System.Collections.Generic;

using CourseSelectionApp.Readers;
using CourseSelectionApp.Models;
using CourseSelectionApp.Services.Interfaces;

using HtmlAgilityPack;
using System.Text;
using System;
using System.Linq;

namespace CourseSelectionApp.Services
{
    public class CourseService : ICourseService
    {
        private const string COURSE_TABLE_XPATH = "//body/table";
        private readonly HtmlWeb _webClient;
        private readonly Uri _courseResourceUri;

        public CourseService(HtmlWeb webClient, string courseResourceUri)
        {
            _webClient = webClient;
            _courseResourceUri = new Uri(courseResourceUri);
        }

        /// <summary>
        /// 取得所有課程資料
        /// </summary>
        /// <returns></returns>
        public IList<Course> GetAllCourses()
        {
            _webClient.OverrideEncoding = Encoding.Default;
            // 取得課程網頁
            HtmlDocument document = _webClient.Load(_courseResourceUri);
            // 取得課程資料表
            var table = document.DocumentNode.SelectSingleNode(COURSE_TABLE_XPATH);

            ICourseTableReader reader = new CourseTableReader(table);
            return reader.GetCourses().AsParallel().Select(DoPostProcess).ToList();
        }

        /// <summary>
        /// 進行課程資料後處理
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        private Course DoPostProcess(Course course)
        {
            var syllabusUri = course.OtherInfo.Syllabus;

            if (syllabusUri != string.Empty)
            {
                course.OtherInfo.Syllabus = CombineUri(
                    _courseResourceUri.Scheme,
                    _courseResourceUri.Host,
                    _courseResourceUri.AbsolutePath.Replace(_courseResourceUri.Segments.Last(), syllabusUri)
                );
            }
            return course;
        }

        /// <summary>
        /// 組合 Uri
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="host"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private string CombineUri(string scheme, string host, string path)
        {
            return scheme + Uri.SchemeDelimiter + host + path;
        }
    }
}

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
    public class CourseCrawlerService : BaseCrawlerService<Course>
    {
        private const string COURSE_TABLE_XPATH = "//body/table";

        public CourseCrawlerService(HtmlWeb webClient) : base(webClient)
        {
        }

        /// <summary>
        /// 取得所有課程資料
        /// </summary>
        /// <returns></returns>
        public override IList<Course> GetResults(Uri uri)
        {
            var document = LoadDocument(uri);
            // 取得課程資料表
            var table = document.DocumentNode.SelectSingleNode(COURSE_TABLE_XPATH);

            IReader<Course> reader = new CourseTableReader(table);
            return reader.GetResults().AsParallel().Select(course => DoPostProcess(uri, course)).ToList();
        }

        /// <summary>
        /// 進行課程資料後處理
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        private Course DoPostProcess(Uri uri, Course course)
        {
            course.OtherInfo.Syllabus = ProcessSyllabusUri(uri, course);
            return course;
        }

        /// <summary>
        /// 串接 syllabus uri
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        private string ProcessSyllabusUri(Uri uri, Course course)
        {
            var syllabusUri = course.OtherInfo.Syllabus;
            if (syllabusUri != string.Empty)
            {
                return CombineUri(uri.Scheme, uri.Host, uri.AbsolutePath.Replace(uri.Segments.Last(), syllabusUri));
            }
            return syllabusUri;
        }
    }
}

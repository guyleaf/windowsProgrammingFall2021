using System;
using System.Collections.Generic;
using System.Linq;

using CourseSelectionApp.Models;
using CourseSelectionApp.Readers;

using HtmlAgilityPack;

namespace CourseSelectionApp.Services
{
    public class ClassCrawlerService : BaseCrawlerService<Class>
    {
        private const string CLASSES_INFO_XPATH = "//body";

        public ClassCrawlerService(HtmlWeb webClient) : base(webClient)
        {
        }

        /// <summary>
        /// 取得班級資料
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public override IList<Class> GetResults(Uri uri)
        {
            var document = LoadDocument(uri);

            var classesInfo = document.DocumentNode.SelectSingleNode(CLASSES_INFO_XPATH);

            IReader<Class> reader = new ClassReader(classesInfo);
            return reader.GetResults().Select(classInfo => DoPostProcess(uri, classInfo)).ToList();
        }

        /// <summary>
        /// 進行班級資料後處理
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="classInfo"></param>
        /// <returns></returns>
        private Class DoPostProcess(Uri uri, Class classInfo)
        {
            var coursesUri = classInfo.CoursesUri;

            classInfo.CoursesUri = CombineUri(
                uri.Scheme,
                uri.Host,
                uri.AbsolutePath.Replace(uri.Segments.Last(), coursesUri)
            );
            return classInfo;
        }
    }
}

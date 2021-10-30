using System;
using System.Collections.Generic;
using System.Text;

using CourseSelectionApp.Services.Interfaces;

using HtmlAgilityPack;

namespace CourseSelectionApp.Services
{
    public abstract class BaseCrawlerService<T> : ICrawlerService<T>
    {
        protected readonly HtmlWeb _webClient;

        protected BaseCrawlerService(HtmlWeb webClient)
        {
            _webClient = webClient;
        }

        /// <summary>
        /// 取得所有課程資料
        /// </summary>
        /// <returns></returns>
        public abstract IList<T> GetResults(Uri uri);

        /// <summary>
        /// 取得網頁資料
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        protected virtual HtmlDocument LoadDocument(Uri uri)
        {
            _webClient.OverrideEncoding = Encoding.Default;
            return _webClient.Load(uri);
        }

        /// <summary>
        /// 組合 Uri
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="host"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        protected string CombineUri(string scheme, string host, string path)
        {
            return scheme + Uri.SchemeDelimiter + host + path;
        }
    }
}

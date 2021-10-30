using System.Collections.Generic;

using HtmlAgilityPack;

namespace CourseSelectionApp.Readers
{
    public abstract class BaseReader<T> : IReader<T>
    {
        /// <summary>
        /// 取得結構化資料資料
        /// </summary>
        /// <returns></returns>
        public abstract IList<T> GetResults();

        /// <summary>
        /// 移除標籤Node
        /// </summary>
        /// <param name="tableRows"></param>
        protected void RemoveNode(HtmlNodeCollection tableRows, int index)
        {
            tableRows.RemoveAt(index);
        }

        /// <summary>
        /// 取得節點文字
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected string GetNodeText(HtmlNodeCollection nodes, int index)
        {
            return nodes[index].InnerText.Trim();
        }

        /// <summary>
        /// 取得節點屬性
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        protected string GetNodeAttributeValue(HtmlNode node, string name, string defaultValue)
        {
            return node.GetAttributeValue(name, defaultValue);
        }
    }
}

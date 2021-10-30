using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseSelectionApp.Models;

using HtmlAgilityPack;

namespace CourseSelectionApp.Readers
{
    public class ClassReader : BaseReader<Class>
    {
        private const int ZERO = 0;
        private const int TWO = 2;
        private const string NODE_URI = "href";
        private const string CLASS_TAG_NAME = "a";
        private const string DEPARTMENT_NAME_DELIMITER = "--";
        private readonly HtmlNode _info;

        public ClassReader(HtmlNode info)
        {
            _info = info;
        }

        /// <summary>
        /// 取得班級資料
        /// </summary>
        /// <returns></returns>
        public override IList<Class> GetResults()
        {
            HtmlNodeCollection nodes = _info.ChildNodes;
            // Remove #text node
            RemoveNode(nodes, ZERO);

            var departmentName = GetNodeText(nodes, ZERO).Split(DEPARTMENT_NAME_DELIMITER.ToCharArray())[TWO].Trim();
            // Remove name node
            RemoveNode(nodes, ZERO);

            return nodes.Where(IsClassNode).Select(node => ReadClassNode(node, departmentName)).ToList();
        }

        /// <summary>
        /// 解析班級節點
        /// </summary>
        /// <param name="classNode"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        private Class ReadClassNode(HtmlNode classNode, string departmentName)
        {
            var nodes = classNode.ChildNodes;

            return new Class()
            {
                DepartmentName = departmentName,
                Name = GetNodeText(nodes, TWO),
                CoursesUri = GetNodeUri(nodes, TWO)
            };
        }

        /// <summary>
        /// 取得節點連結
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetNodeUri(HtmlNodeCollection nodes, int index)
        {
            return GetNodeAttributeValue(nodes[index], NODE_URI, string.Empty);
        }

        /// <summary>
        /// 是否為班級節點
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsClassNode(HtmlNode node)
        {
            return node.Descendants(CLASS_TAG_NAME).Any();
        }
    }
}

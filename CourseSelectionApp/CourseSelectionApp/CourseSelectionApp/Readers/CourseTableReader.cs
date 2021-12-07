﻿using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

using CourseSelectionApp.Models.CourseObjects;
using CourseSelectionApp.Readers.NodeFormats;
using CourseSelectionApp.Models.Extensions;

namespace CourseSelectionApp.Readers
{
    public class CourseTableReader : BaseReader<Course>
    {
        private const char COURSE_TIME_DELIMITER = ' ';
        private const string NODE_URI = "href";
        private readonly HtmlNode _table;

        public CourseTableReader(HtmlNode table)
        {
            _table = table;
        }

        /// <summary>
        /// 取得課程資料
        /// </summary>
        /// <returns></returns>
        public override IList<Course> GetResults()
        {
            HtmlNodeCollection tableRows = _table.ChildNodes;
            // 移除tbody
            RemoveNode(tableRows, 0);
            // 移除<tr>資工三
            RemoveNode(tableRows, 0);
            // 移除table header
            RemoveNode(tableRows, 0);
            // 移除<tr>小計
            RemoveNode(tableRows, tableRows.Count - 1);

            return tableRows.Select(row => ReadCourseNode(row)).ToList();
        }

        /// <summary>
        /// 解析課程節點
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private Course ReadCourseNode(HtmlNode courseNode)
        {
            var nodes = courseNode.ChildNodes;
            // Remove #text
            RemoveNode(nodes, 0);

            return new Course()
            {
                Id = GetNodeText(nodes, (int)CourseNode.Id),
                Info = ReadCourseInfo(nodes),
                SelectionInfo = ReadCourseSelectionInfo(nodes),
                CourseTime = ReadCourseTime(nodes),
                Status = ReadCourseStatus(nodes),
                OtherInfo = ReadCourseOtherInfo(nodes)
            };
        }

        /// <summary>
        /// 解析課程基本資料
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private CourseInfo ReadCourseInfo(HtmlNodeCollection nodes)
        {
            return new CourseInfo()
            {
                Name = GetNodeText(nodes, (int)CourseNode.Name),
                Stage = GetNodeText(nodes, (int)CourseNode.Stage),
                Teacher = GetNodeText(nodes, (int)CourseNode.Teacher),
                ClassRoom = GetNodeText(nodes, (int)CourseNode.ClassRoom),
                RequiredOrElectiveCourse = GetNodeText(nodes, (int)CourseNode.RequiredOrElectiveCourse),
                TeachingAssistant = GetNodeText(nodes, (int)CourseNode.TeachingAssistant)
            };
        }

        /// <summary>
        /// 解析課程選課資料
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private CourseSelectionInfo ReadCourseSelectionInfo(HtmlNodeCollection nodes)
        {
            return new CourseSelectionInfo()
            {
                Credits = GetNodeText(nodes, (int)CourseNode.Credits),
                Hours = GetNodeText(nodes, (int)CourseNode.Hours)
            };
        }

        /// <summary>
        /// 解析上課時間表
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private CourseTime ReadCourseTime(HtmlNodeCollection nodes)
        {
            var courseTime = new CourseTime();
            courseTime.Sunday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Sunday)));
            courseTime.Monday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Monday)));
            courseTime.Tuesday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Tuesday)));
            courseTime.Wednesday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Wednesday)));
            courseTime.Thursday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Thursday)));
            courseTime.Friday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Friday)));
            courseTime.Saturday.AddRange(GetSplittedText(GetNodeText(nodes, (int)CourseNode.Saturday)));
            return courseTime;
        }

        /// <summary>
        /// 取得切割後資料
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IList<string> GetSplittedText(string texts)
        {
            return texts.Split(COURSE_TIME_DELIMITER)
                .Where(text => !string.IsNullOrWhiteSpace(text))
                .ToList();
        }

        /// <summary>
        /// 解析課程狀態
        /// </summary>
        /// <param name="numberOfStudents">學生數量</param>
        /// <param name="numberOfDropStudents">徹選學生數量</param>
        /// <returns></returns>
        private CourseStatus ReadCourseStatus(HtmlNodeCollection nodes)
        {
            return new CourseStatus()
            {
                NumberOfStudents = GetNodeText(nodes, (int)CourseNode.NumberOfStudents),
                NumberOfDropStudents = GetNodeText(nodes, (int)CourseNode.NumberOfDropStudents)
            };
        }

        /// <summary>
        /// 解析課程詳細資料
        /// </summary>
        /// <param name="language">授課語言</param>
        /// <param name="syllabus">教學大綱與進度表</param>
        /// <param name="note">備註</param>
        /// <param name="audit">隨班附讀</param>
        /// <param name="experiment">實驗實習</param>
        /// <returns></returns>
        private CourseOtherInfo ReadCourseOtherInfo(HtmlNodeCollection nodes)
        {
            return new CourseOtherInfo()
            {
                Language = GetNodeText(nodes, (int)CourseNode.Language),
                Syllabus = GetNodeUri(nodes, (int)CourseNode.Syllabus),
                Note = GetNodeText(nodes, (int)CourseNode.Note),
                Audit = GetNodeText(nodes, (int)CourseNode.Audit),
                Experiment = GetNodeText(nodes, (int)CourseNode.Experiment)
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
            return GetNodeAttributeValue(nodes[index].ChildNodes.FirstOrDefault(), NODE_URI, "");
        }

        /// <summary>
        /// 取得節點文字
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private new string GetNodeText(HtmlNodeCollection nodes, int index)
        {
            return base.GetNodeText(nodes, index);
        }
    }
}

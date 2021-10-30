using System.Collections.Generic;

using CourseSelectionApp.Models;

namespace CourseSelectionApp.Readers
{
    public interface IReader<T>
    {
        /// <summary>
        /// 取得結構化資料資料
        /// </summary>
        /// <returns></returns>
        IList<T> GetResults();
    }
}
using System.Collections.Generic;
using System.Linq;

namespace CourseSelectionApp.Extensions
{
    public static class ICollectionExtensions
    {
        /// <summary>
        /// 新增清單所有物品至 collection 中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            items.ToList()
                .ForEach(item => collection.Add(item));
        }

        /// <summary>
        /// 依照 collection 內容，移除清單所有物品
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            items.ToList()
                .ForEach(item => collection.Remove(item));
        }
    }
}

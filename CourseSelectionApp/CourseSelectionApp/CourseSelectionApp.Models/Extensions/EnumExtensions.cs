using System;
using System.Linq;
using System.Reflection;

using CourseSelectionApp.Models.Attributes;

namespace CourseSelectionApp.Models.Extensions
{

    public static class EnumExtensions
    {
        /// <summary>
        /// 取得對應字串屬性數值
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum target)
        {
            var targetType = target.GetType();
            FieldInfo targetInfo = targetType.GetRuntimeField(target.ToString());
            var attributeInfo = (StringValueAttribute)targetInfo.GetCustomAttributes(typeof(StringValueAttribute), false).First();
            return attributeInfo.Value;
        }
    }
}

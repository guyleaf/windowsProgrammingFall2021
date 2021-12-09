using DrawingModel.Attributes;
using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingModel
{
    public static class ShapesFactory
    {
        /// <summary>
        /// 依 ShapeType 建構對應 Shape 物件
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public static IShape CreateShape(ShapeType shapeType)
        {
            var attribute = GetShapeTargetAttribute(shapeType);
            return Activator.CreateInstance(attribute.ShapeClassType) as IShape;
        }

        /// <summary>
        /// 取得 ShapeTargetAttribute
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private static ShapeTargetAttribute GetShapeTargetAttribute(ShapeType shapeType)
        {
            return shapeType.GetType().GetMember(shapeType.ToString())
                .FirstOrDefault()
                .GetCustomAttributes(typeof(ShapeTargetAttribute), false)
                .FirstOrDefault() as ShapeTargetAttribute;
        }
    }
}

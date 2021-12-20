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
        private const string ERROR_MESSAGE = "None shape type.";

        /// <summary>
        /// 依 ShapeType 建構對應 Shape 物件
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public static IShape CreateShape(ShapeType shapeType)
        {
            var attribute = GetShapeTargetAttribute(shapeType);

            if (attribute == null)
            {
                throw new Exception(ERROR_MESSAGE);
            }

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
                .First()
                .GetCustomAttributes(typeof(ShapeTargetAttribute), false)
                .FirstOrDefault() as ShapeTargetAttribute;
        }
    }
}

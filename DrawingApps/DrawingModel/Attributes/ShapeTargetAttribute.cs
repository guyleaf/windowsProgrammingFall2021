using System;

namespace DrawingModel.Attributes
{
    public class ShapeTargetAttribute : Attribute
    {
        public ShapeTargetAttribute(Type shapeClass)
        {
            ShapeClassType = shapeClass;
        }

        public Type ShapeClassType
        { 
            get;
        }
    }
}

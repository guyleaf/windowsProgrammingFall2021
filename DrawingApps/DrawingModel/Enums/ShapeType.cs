using DrawingModel.Attributes;
using DrawingModel.Shapes;

namespace DrawingModel.Enums
{
    public enum ShapeType
    {
        Unknown = -1,
        [ShapeTarget(typeof(Rectangle))]
        Rectangle,
        [ShapeTarget(typeof(Ellipse))]
        Ellipse
    }
}

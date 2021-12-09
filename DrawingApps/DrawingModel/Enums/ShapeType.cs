using DrawingModel.Attributes;
using DrawingModel.Shapes;

namespace DrawingModel.Enums
{
    public enum ShapeType
    {
        [ShapeTarget(typeof(Rectangle))]
        Rectangle,
        [ShapeTarget(typeof(Ellipse))]
        Ellipse
    }
}

using DrawingModel.Attributes;
using DrawingModel.Shapes;

namespace DrawingModel.Enums
{
    public enum ShapeType
    {
        None = -1,
        [ShapeTarget(typeof(Rectangle))]
        Rectangle,
        [ShapeTarget(typeof(Ellipse))]
        Ellipse,
        [ShapeTarget(typeof(Line))]
        Line
    }
}

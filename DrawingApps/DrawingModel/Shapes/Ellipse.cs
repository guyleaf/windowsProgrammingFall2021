using DrawingModel.Interfaces;

namespace DrawingModel.Shapes
{
    public class Ellipse : IShape
    {
        private readonly double _x1;
        private readonly double _y1;
        private readonly double _x2;
        private readonly double _y2;

        public Ellipse(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        /// <summary>
        /// 畫圖
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(_x1, _y1, _x2, _y2);
        }
    }
}

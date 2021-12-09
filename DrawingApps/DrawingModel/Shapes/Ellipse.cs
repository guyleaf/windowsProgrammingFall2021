using DrawingModel.Interfaces;

namespace DrawingModel.Shapes
{
    public class Ellipse : IShape
    {
        public Ellipse(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public Ellipse()
        {

        }

        public double X1
        {
            get; set;
        }

        public double Y1
        {
            get; set;
        }

        public double X2
        {
            get; set;
        }

        public double Y2
        {
            get; set;
        }

        /// <summary>
        /// 畫圖
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            if (X1 <= X2)
            {
                graphics.DrawEllipse(X1, Y1, X2, Y2);
            }
            else
            {
                graphics.DrawEllipse(X2, Y2, X1, Y1);
            }
        }
    }
}

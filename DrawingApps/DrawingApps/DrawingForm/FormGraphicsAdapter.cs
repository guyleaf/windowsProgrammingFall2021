using DrawingModel.Interfaces;

using System.Drawing;

namespace DrawingForm
{
    public class FormGraphicsAdapter : IGraphics
    {
        private const float RADIUS_OF_DOT = 3.0F;
        private const float DASHED_LINE_WIDTH = 2.5F;
        private const float DASHED_LINE_LENGTH_BETWEEN_DASHED_LINE = 3.0F;
        private readonly Graphics _graphics;
        private readonly Pen _penForDashedLine;
        private readonly Pen _blackPen;
        private readonly Brush _brushForRectangle;
        private readonly Brush _brushForEllipse;
        private readonly Brush _brushForDot;

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
            _brushForEllipse = new SolidBrush(Color.Orange);
            _brushForDot = new SolidBrush(Color.White);
            _brushForRectangle = new SolidBrush(Color.Yellow);
            _blackPen = Pens.Black;

            _penForDashedLine = Pens.Red.Clone() as Pen;
            _penForDashedLine.Width = DASHED_LINE_WIDTH;
            _penForDashedLine.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            _penForDashedLine.DashPattern = new float[] { DASHED_LINE_LENGTH_BETWEEN_DASHED_LINE, DASHED_LINE_LENGTH_BETWEEN_DASHED_LINE };
        }

        /// <summary>
        /// 清除全部
        /// </summary>
        public void ClearAll()
        {
            // Winforms 渲染不須移除畫圖物件
        }

        /// <summary>
        /// 畫橢圓形
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public void DrawEllipse(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var width = bottomRightX - topLeftX;
            var height = bottomRightY - topLeftY;

            var rectangle = new RectangleF((float)topLeftX, (float)topLeftY, (float)width, (float)height);
            DrawEllipse(rectangle, _brushForEllipse, _blackPen);
        }

        /// <summary>
        /// 畫虛線
        /// </summary>
        /// TODO: Change to use Rectangle with dashed format
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawDashedRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var width = bottomRightX - topLeftX;
            var height = bottomRightY - topLeftY;
            var rectangle = new Rectangle((int)topLeftX, (int)topLeftY, (int)width, (int)height);

            _graphics.DrawRectangle(_penForDashedLine, rectangle);
        }

        /// <summary>
        /// 畫實線
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_blackPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        /// <summary>
        /// 畫長方形
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var width = bottomRightX - topLeftX;
            var height = bottomRightY - topLeftY;
            var rectangle = new Rectangle((int)topLeftX, (int)topLeftY, (int)width, (int)height);

            _graphics.FillRectangle(_brushForRectangle, rectangle);
            _graphics.DrawRectangle(_blackPen, rectangle);
        }

        /// <summary>
        /// 畫圓點
        /// </summary>
        /// <param name="middleX"></param>
        /// <param name="middleY"></param>
        public void DrawDot(double middleX, double middleY)
        {
            var diameter = RADIUS_OF_DOT + RADIUS_OF_DOT;
            var rectangle = new RectangleF((float)middleX - RADIUS_OF_DOT, (float)middleY - RADIUS_OF_DOT, diameter, diameter);
            DrawEllipse(rectangle, _brushForDot, _blackPen);
        }

        /// <summary>
        /// 畫橢圓形
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        private void DrawEllipse(RectangleF rectangle, Brush brush, Pen pen)
        {
            _graphics.FillEllipse(brush, rectangle);
            _graphics.DrawEllipse(pen, rectangle);
        }
    }
}

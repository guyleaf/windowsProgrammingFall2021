using DrawingModel.Interfaces;

using System.Drawing;

namespace DrawingForm
{
    public class FormGraphicsAdapter : IGraphics
    {
        private const float DASHED_LINE_WIDTH = 1.8F;
        private const float DASHED_LINE_LENGTH_BETWEEN_DASHED_LINE = 1.2F;
        private readonly Graphics _graphics;
        private readonly Pen _penForDashedLine;

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
            _penForDashedLine = Pens.DarkGray.Clone() as Pen;
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
            _graphics.DrawEllipse(Pens.Black, (float)topLeftX, (float)topLeftY, (float)width, (float)height);
        }

        /// <summary>
        /// 畫線
        /// </summary>
        /// TODO: Change to use Rectangle with dashed format
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawDashedLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_penForDashedLine, (float)x1, (float)y1, (float)x2, (float)y2);
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
            _graphics.DrawRectangle(Pens.Black, (float)topLeftX, (float)topLeftY, (float)width, (float)height);
        }
    }
}

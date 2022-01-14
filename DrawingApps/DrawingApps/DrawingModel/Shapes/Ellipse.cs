using DrawingModel.Interfaces;

using System;

namespace DrawingModel.Shapes
{
    public class Ellipse : IShape
    {
        private const string FORMATTED_INFO_MESSAGE = "Ellipse({0}, {1}, {2}, {3})";

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

        public string Info
        {
            get
            {
                var topLeftX = Math.Min(X1, X2);
                var topLeftY = Math.Min(Y1, Y2);
                var rightBottomX = Math.Max(X1, X2);
                var rightBottomY = Math.Max(Y1, Y2);

                return string.Format(FORMATTED_INFO_MESSAGE, topLeftX, topLeftY, rightBottomX, rightBottomY);
            }
        }

        /// <summary>
        /// 繪製圖
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            var topLeftX = Math.Min(X1, X2);
            var topLeftY = Math.Min(Y1, Y2);
            var rightBottomX = Math.Max(X1, X2);
            var rightBottomY = Math.Max(Y1, Y2);

            graphics.DrawEllipse(topLeftX, topLeftY, rightBottomX, rightBottomY);
        }

        /// <summary>
        /// 是否位於目標座標
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        public bool IsLocatedIn(double locationX, double locationY)
        {
            var topLeftX = Math.Min(X1, X2);
            var topLeftY = Math.Min(Y1, Y2);
            var rightBottomX = Math.Max(X1, X2);
            var rightBottomY = Math.Max(Y1, Y2);

            return topLeftX <= locationX &&
                locationX <= rightBottomX &&
                topLeftY <= locationY &&
                locationY <= rightBottomY;
        }

        /// <summary>
        /// 移動至
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        public void MoveTo(double topLeftX, double topLeftY)
        {
            var length = topLeftX - X1;
            var height = topLeftY - Y1;

            X1 = topLeftX;
            Y1 = topLeftY;
            X2 += length;
            Y2 += height;
        }

        /// <summary>
        /// 複製圖形
        /// </summary>
        /// <returns></returns>
        public IShape Clone()
        {
            return new Ellipse
            {
                X1 = X1,
                Y1 = Y1,
                X2 = X2,
                Y2 = Y2
            };
        }
    }
}

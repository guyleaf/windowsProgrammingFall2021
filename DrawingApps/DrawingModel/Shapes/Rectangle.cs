using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Shapes
{
    public class Rectangle : IShape
    {
        public Rectangle()
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
            var topLeftX = X1;
            var topLeftY = Y1;
            var rightBottomX = X2;
            var rightBottomY = Y2;

            if (X1 > X2)
            {
                (topLeftX, rightBottomX) = (rightBottomX, topLeftX);
            }

            if (Y1 > Y2)
            {
                (topLeftY, rightBottomY) = (rightBottomY, topLeftY);
            }

            graphics.DrawRectangle(topLeftX, topLeftY, rightBottomX, rightBottomY);
        }
    }
}

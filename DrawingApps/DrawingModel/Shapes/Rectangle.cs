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
                Swap(ref topLeftX, ref rightBottomX);
            }
            if (Y1 > Y2)
            {
                Swap(ref topLeftY, ref rightBottomY);
            }

            graphics.DrawRectangle(topLeftX, topLeftY, rightBottomX, rightBottomY);
        }
        
        /// <summary>
        /// 交換數值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        private void Swap(ref double value1, ref double value2)
        {
            double value = value1;
            value1 = value2;
            value2 = value;
        }
    }
}

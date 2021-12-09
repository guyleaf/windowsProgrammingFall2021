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
            if (X1 <= X2)
            {
                graphics.DrawRectangle(X1, Y1, X2, Y2);
            }
            else
            {
                graphics.DrawRectangle(X2, Y2, X1, Y1);
            }
        }
    }
}

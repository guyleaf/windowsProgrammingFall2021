using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm
{
    public class FormGraphicsAdapter : IGraphics
    {
        private readonly Graphics _graphics;

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// 清除全部
        /// </summary>
        public void ClearAll()
        {
            // Winforms 渲染不須移除畫圖物件
        }

        public void DrawEllipse(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            _graphics.DrawEllipse(Pens.Black, GetRectangleF(topLeftX, topLeftY, bottomRightX, bottomRightY));
        }

        public void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            _graphics.DrawRectangle(Pens.Black, GetRectangle(topLeftX, topLeftY, bottomRightX, bottomRightY));
        }

        /// <summary>
        /// 取得 RectangleF 物件
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        /// <returns></returns>
        private RectangleF GetRectangleF(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var width = bottomRightX - topLeftX;
            var height = bottomRightY - topLeftY;
            return new RectangleF((float)topLeftX, (float)topLeftY, (float)width, (float)height);
        }

        /// <summary>
        /// 取得 Rectangle 物件
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        /// <returns></returns>
        private Rectangle GetRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var width = bottomRightX - topLeftX;
            var height = bottomRightY - topLeftY;
            return new Rectangle((int)topLeftX, (int)topLeftY, (int)width, (int)height);
        }
    }
}

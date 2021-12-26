﻿using DrawingModel.Interfaces;

using System;

namespace DrawingModel.Shapes
{
    public class Ellipse : IShape
    {
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
    }
}

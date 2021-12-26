﻿using DrawingModel.Interfaces;

namespace DrawingModel.Shapes
{
    public class Line : IShape
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;

        private readonly IShape _firstShape;
        private readonly IShape _secondShape;

        public Line()
        {
            _x1 = _y1 = _x2 = _y2 = 0;
        }

        public Line(IShape firstShape, IShape secondShape)
        {
            _firstShape = firstShape;
            _secondShape = secondShape;
        }

        public double X1
        {
            get
            {
                if (_firstShape != null)
                {
                    return (_firstShape.X1 + _firstShape.X2) / 2;
                }
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }

        public double Y1
        {
            get
            {
                if (_firstShape != null)
                {
                    return (_firstShape.Y1 + _firstShape.Y2) / 2;
                }
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }

        public double X2
        {
            get
            {
                if (_secondShape != null)
                {
                    return (_secondShape.X1 + _secondShape.X2) / 2;
                }
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public double Y2
        {
            get
            {
                if (_secondShape != null)
                {
                    return (_secondShape.Y1 + _secondShape.Y2) / 2;
                }
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        /// <summary>
        /// 畫圖
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
        }

        /// <summary>
        /// 是否位於目標座標
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        public bool IsLocatedIn(double locationX, double locationY)
        {
            return false;
        }
    }
}

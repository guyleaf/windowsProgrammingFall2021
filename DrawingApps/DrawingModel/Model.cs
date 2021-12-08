using DrawingModel.Interfaces;
using DrawingModel.Shapes;

using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class Model : IModel
    {
        public event Action _modelChanged;

        private readonly DrawingPoint _startHintPoint;
        private readonly DrawingPoint _endHintPoint;

        private bool _isPressed;
        private readonly IList<IShape> _shapes;

        public Model()
        {
            _startHintPoint = new DrawingPoint();
            _endHintPoint = new DrawingPoint();
            _shapes = new List<IShape>();
            _isPressed = false;
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PressPointer(double locationX, double locationY)
        {
            if (locationX > 0 && locationY > 0)
            {
                _startHintPoint.X = locationX;
                _startHintPoint.Y = locationY;
                _isPressed = true;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                _endHintPoint.X = locationX;
                _endHintPoint.Y = locationY;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="mode"></param>
        public void ReleasePointer(double locationX, double locationY, DrawingMode mode)
        {
            if (_isPressed)
            {
                var endPoint = new DrawingPoint
                { 
                    X = locationX, Y = locationY };

                IShape shape = CreateShape(_startHintPoint, endPoint, mode);
                _shapes.Add(shape);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// 清除所有畫布
        /// </summary>
        public void Clear()
        {
            _shapes.Clear();
            _isPressed = false;
            NotifyModelChanged();
        }
        
        /// <summary>
        /// 建立圖形
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private IShape CreateShape(DrawingPoint startPoint, DrawingPoint endPoint, DrawingMode mode)
        {
            switch (mode)
            {
                case DrawingMode.Rectangle:
                    return new Rectangle(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                case DrawingMode.Ellipse:
                    return new Ellipse(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 通知訂閱者
        /// </summary>
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }
    }
}

using DrawingModel.Enums;
using DrawingModel.Interfaces;

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
        private ShapeType _shapeType;
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
        public void ReleasePointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                IShape shape = ShapesFactory.CreateShape(_shapeType);
                shape.X1 = _startHintPoint.X;
                shape.Y1 = _startHintPoint.Y;
                shape.X2 = locationX;
                shape.Y2 = locationY;

                _shapes.Add(shape);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// 設置圖形種類
        /// </summary>
        /// <param name="shapeType"></param>
        public void SetShapeType(ShapeType shapeType)
        {
            _shapeType = shapeType;
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

using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class Model : IModel
    {
        private const string DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE = "Drawing Shape Type should be chosen before drawing.";

        public event Action _modelChanged;

        private bool _isPressed;
        private ShapeType _drawingShapeType;

        private IShape _drawingShape;
        private readonly IList<IShape> _shapes;

        public Model()
        {
            _shapes = new List<IShape>();
            _isPressed = false;
            _drawingShapeType = ShapeType.Unknown;
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PressPointer(double locationX, double locationY)
        {
            EnsureDrawingShapeTypeIsChosen();
            if (locationX > 0 && locationY > 0)
            {
                _drawingShape.X1 = locationX;
                _drawingShape.Y1 = locationY;
                _isPressed = true;
            }
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            EnsureDrawingShapeTypeIsChosen();
            if (_isPressed)
            {
                _drawingShape.X2 = locationX;
                _drawingShape.Y2 = locationY;
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
            EnsureDrawingShapeTypeIsChosen();
            if (_isPressed)
            {
                IShape shape = ShapesFactory.CreateShape(_drawingShapeType);
                shape.X1 = _drawingShape.X1;
                shape.Y1 = _drawingShape.Y1;
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
            _drawingShapeType = shapeType;
            _drawingShape = ShapesFactory.CreateShape(shapeType);
        }

        /// <summary>
        /// 渲染/繪圖
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
            if (_isPressed)
            {
                _drawingShape.Draw(graphics);
            }
        }

        /// <summary>
        /// 清除所有畫布
        /// </summary>
        public void Clear()
        {
            _shapes.Clear();
            _isPressed = false;
            _drawingShape = null;
            _drawingShapeType = ShapeType.Unknown;
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

        /// <summary>
        /// 檢查 _drawingShapeType 是否已設置
        /// </summary>
        private void EnsureDrawingShapeTypeIsChosen()
        {
            if (_drawingShapeType == ShapeType.Unknown)
            {
                throw new Exception(DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE);
            }
        }
    }
}

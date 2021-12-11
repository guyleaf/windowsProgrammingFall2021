using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class Model : IModel
    {
        public event Action _modelChanged;
        private const string DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE = "Drawing Shape Type should be chosen before drawing.";

        private bool _isPressed;
        private ShapeType _currentDrawingShapeType;

        private IShape _currentDrawingShape;
        private readonly IList<IShape> _shapes;

        public Model()
        {
            _shapes = new List<IShape>();
            _isPressed = false;
            _currentDrawingShapeType = ShapeType.None;
        }

        public ShapeType CurrentDrawingShapeType
        {
            get
            {
                return _currentDrawingShapeType;
            }
            set
            {
                _currentDrawingShapeType = value;
                _currentDrawingShape = ShapesFactory.CreateShape(value);
                NotifyModelChanged();
            }
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
                _currentDrawingShape.X1 = locationX;
                _currentDrawingShape.Y1 = locationY;
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
                _currentDrawingShape.X2 = locationX;
                _currentDrawingShape.Y2 = locationY;
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
                IShape shape = ShapesFactory.CreateShape(_currentDrawingShapeType);
                shape.X1 = _currentDrawingShape.X1;
                shape.Y1 = _currentDrawingShape.Y1;
                shape.X2 = locationX;
                shape.Y2 = locationY;

                _shapes.Add(shape);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// 渲染/繪圖
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
            if (_isPressed)
            {
                _currentDrawingShape.Draw(graphics);
                DrawDashedLines(graphics);
            }
        }

        /// <summary>
        /// 清除所有畫布
        /// </summary>
        public void Clear()
        {
            _shapes.Clear();
            _isPressed = false;
            _currentDrawingShape = null;
            _currentDrawingShapeType = ShapeType.None;
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
        /// 檢查 _currentDrawingShapeType 是否已設置
        /// </summary>
        private void EnsureDrawingShapeTypeIsChosen()
        {
            if (_currentDrawingShapeType == ShapeType.None)
            {
                throw new Exception(DRAWING_SHAPE_TYPE_NOT_SPECIFIED_MESSAGE);
            }
        }

        /// <summary>
        /// 畫虛線
        /// </summary>
        /// TODO: Consider moving to seperate DashedLine Object
        private void DrawDashedLines(IGraphics graphics)
        {
            graphics.DrawDashedLine(
                _currentDrawingShape.X1, _currentDrawingShape.Y1, _currentDrawingShape.X2, _currentDrawingShape.Y1);
            graphics.DrawDashedLine(
                _currentDrawingShape.X1, _currentDrawingShape.Y1, _currentDrawingShape.X1, _currentDrawingShape.Y2);
            graphics.DrawDashedLine(
                _currentDrawingShape.X1, _currentDrawingShape.Y2, _currentDrawingShape.X2, _currentDrawingShape.Y2);
            graphics.DrawDashedLine(
                _currentDrawingShape.X2, _currentDrawingShape.Y1, _currentDrawingShape.X2, _currentDrawingShape.Y2);
        }
    }
}

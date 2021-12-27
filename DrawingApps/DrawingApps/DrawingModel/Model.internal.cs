using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System;

namespace DrawingModel
{
    public partial class Model
    {
        /// <summary>
        /// 畫圖形至最上層
        /// </summary>
        /// <param name="shape"></param>
        public void DrawShapeInFront(IShape shape)
        {
            _shapes.Add(shape);
        }

        /// <summary>
        /// 畫圖形至最下層
        /// </summary>
        /// <param name="shape"></param>
        public void DrawShapeInBack(IShape shape)
        {
            _shapes.Insert(0, shape);
        }

        /// <summary>
        /// 移除圖形
        /// </summary>
        public void RemoveShape(IShape shape)
        {
            _shapes.Remove(shape);
        }

        /// <summary>
        /// 移除所有圖形
        /// </summary>
        public void RemoveAllShapes()
        {
            _shapes.Clear();
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
        /// 畫虛線
        /// </summary>
        private void DrawDashedLines(IGraphics graphics, IShape shape)
        {
            var topLeftX = Math.Min(shape.X1, shape.X2);
            var topLeftY = Math.Min(shape.Y1, shape.Y2);
            var rightBottomX = Math.Max(shape.X1, shape.X2);
            var rightBottomY = Math.Max(shape.Y1, shape.Y2);

            graphics.DrawDashedRectangle(topLeftX, topLeftY, rightBottomX, rightBottomY);
        }

        /// <summary>
        /// 畫圓點
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawDots(IGraphics graphics, IShape shape)
        {
            graphics.DrawDot(shape.X1, shape.Y1);
            graphics.DrawDot(shape.X2, shape.Y2);
            graphics.DrawDot(shape.X1, shape.Y2);
            graphics.DrawDot(shape.X2, shape.Y1);
        }

        /// <summary>
        /// 建立 Shape
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        private IShape CreateShape(double locationX, double locationY)
        {
            IShape shape;
            if (_currentDrawingShapeType == ShapeType.Line)
            {
                shape = CreateLine(locationX, locationY);
            }
            else
            {
                shape = ShapesFactory.CreateShape(_currentDrawingShapeType);
                shape.X1 = _currentDrawingShape.X1;
                shape.Y1 = _currentDrawingShape.Y1;
                shape.X2 = locationX;
                shape.Y2 = locationY;
            }

            return shape;
        }

        /// <summary>
        /// 建立 Line
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        private IShape CreateLine(double locationX, double locationY)
        {
            var firstShape = FindShapeByLocation(_currentDrawingShape.X1, _currentDrawingShape.Y1);
            if (firstShape == null)
            {
                return null;
            }
            var secondShape = FindShapeByLocation(locationX, locationY);
            if (secondShape == null)
            {
                return null;
            }

            return ShapesFactory.CreateShape(_currentDrawingShapeType, firstShape, secondShape);
        }

        /// <summary>
        /// 尋找目標位置對應的 shape
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        private IShape FindShapeByLocation(double locationX, double locationY)
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                var shape = _shapes[i];
                if (shape.IsLocatedIn(locationX, locationY))
                {
                    return shape;
                }
            }

            return null;
        }

        /// <summary>
        /// 重置 Drawing Shape
        /// </summary>
        private void ResetDrawingShape()
        {
            _currentDrawingShape = null;
            _currentDrawingShapeType = ShapeType.None;
        }
    }
}

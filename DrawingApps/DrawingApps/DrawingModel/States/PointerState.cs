using DrawingModel.Commands;
using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;

namespace DrawingModel.States
{
    public class PointerState : IState
    {
        private readonly Model _model;
        private IShape _selectedShape;
        private IShape _shape;

        private double _pointerLocationX;
        private double _pointerLocationY;

        private readonly CommandManager _commandManager;

        public PointerState(CommandManager commandManager, Model model)
        {
            _commandManager = commandManager;
            _model = model;
            _pointerLocationX = _pointerLocationY = 0;
        }

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PressPointer(double locationX, double locationY)
        {
            _shape = _model.FindShapeByLocation(locationX, locationY);
            if (_shape != null)
            {
                _selectedShape = ShapesFactory.CreateShape(_shape);
                _pointerLocationX = locationX;
                _pointerLocationY = locationY;
            }
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            if (_shape != null)
            {
                var length = locationX - _pointerLocationX;
                var height = locationY - _pointerLocationY;

                if (length != 0 || height != 0)
                {
                    _shape.MoveTo(_selectedShape.X1 + length, _selectedShape.Y1 + height);
                }
            }
        }

        /// <summary>
        /// 渲染/繪圖
        /// </summary>
        /// <param name="graphics"></param>
        public void ReleasePointer(double locationX, double locationY)
        {
            if (_shape != null)
            {
                var length = locationX - _pointerLocationX;
                var height = locationY - _pointerLocationY;

                var originalTopLeftX = _selectedShape.X1;
                var originalTopLeftY = _selectedShape.Y1;
                if (length != 0 || height != 0)
                {
                    _commandManager.Execute(new MoveCommand(
                        _shape, originalTopLeftX, originalTopLeftY, originalTopLeftX + length, originalTopLeftY + height));
                }
            }
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void Draw(IGraphics graphics)
        {
            if (_shape != null)
            {
                _shape.Draw(graphics);
                DrawDashedLines(graphics, _shape);
                DrawDots(graphics, _shape);
                graphics.DrawString(866, 598, string.Format("Selected : {0}", _shape.Info));
            }
        }

        /// <summary>
        /// 繪製虛線
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
        /// 繪製圓點
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawDots(IGraphics graphics, IShape shape)
        {
            graphics.DrawDot(shape.X1, shape.Y1);
            graphics.DrawDot(shape.X2, shape.Y2);
            graphics.DrawDot(shape.X1, shape.Y2);
            graphics.DrawDot(shape.X2, shape.Y1);
        }
    }
}

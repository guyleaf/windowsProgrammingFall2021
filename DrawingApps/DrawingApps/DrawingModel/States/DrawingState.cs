using DrawingModel.Commands;
using DrawingModel.Interfaces;

using System;

namespace DrawingModel.States
{
    public class DrawingState : IState
    {
        private readonly Model _model;
        private readonly IShape _drawingShape;

        private readonly CommandManager _commandManager;

        public DrawingState(CommandManager commandManager, Model model, IShape drawingShape)
        {
            _commandManager = commandManager;
            _model = model;
            _drawingShape = drawingShape;
        }

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="mode"></param>
        public void PressPointer(double locationX, double locationY)
        {
            _drawingShape.X1 = locationX;
            _drawingShape.Y1 = locationY;
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            _drawingShape.X2 = locationX;
            _drawingShape.Y2 = locationY;
        }

        /// <summary>
        /// 渲染/繪圖
        /// </summary>
        /// <param name="graphics"></param>
        public void ReleasePointer(double locationX, double locationY)
        {
            var shape = ShapesFactory.CreateShape(_drawingShape);
            _commandManager.Execute(new DrawCommand(_model, shape));
            _model.ChoosePointer();
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void Draw(IGraphics graphics)
        {
            _drawingShape.Draw(graphics);
            DrawDashedLines(graphics, _drawingShape);
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
    }
}

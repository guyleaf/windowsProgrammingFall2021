using DrawingModel.Commands;
using DrawingModel.Interfaces;
using DrawingModel.Shapes;

using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.States
{
    public class DrawingLineState : IState
    {
        private readonly Model _model;
        private readonly CommandManager _commandManager;

        private readonly IShape _line;

        public DrawingLineState(CommandManager commandManager, Model model)
        {
            _model = model;
            _commandManager = commandManager;
            _line = new Line();
        }

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="mode"></param>
        public void PressPointer(double locationX, double locationY)
        {
            _line.X1 = locationX;
            _line.Y1 = locationY;
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            _line.X2 = locationX;
            _line.Y2 = locationY;
        }

        /// <summary>
        /// 渲染/繪圖
        /// </summary>
        /// <param name="graphics"></param>
        public void ReleasePointer(double locationX, double locationY)
        {
            var line = CreateLine(locationX, locationY);
            if (line != null)
            {
                _commandManager.Execute(new DrawCommand(_model, line, true));
                _model.ChoosePointer();
            }
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void Draw(IGraphics graphics)
        {
            _line.Draw(graphics);
        }

        /// <summary>
        /// 建立 Line
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        private IShape CreateLine(double locationX, double locationY)
        {
            var firstShape = _model.FindShapeByLocation(_line.X1, _line.Y1);
            if (firstShape == null)
            {
                return null;
            }
            var secondShape = _model.FindShapeByLocation(locationX, locationY);
            if (secondShape == null)
            {
                return null;
            }

            return new Line(firstShape, secondShape);
        }
    }
}

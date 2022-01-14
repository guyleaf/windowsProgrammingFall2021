using DrawingModel.Commands;
using DrawingModel.Enums;
using DrawingModel.Interfaces;
using DrawingModel.States;

using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public partial class Model : IModel
    {
        public event Action _modelChanged;

        private bool _isPressed;
        private readonly IList<IShape> _shapes;

        private readonly CommandManager _commandManager;
        private IState _state;

        public Model(CommandManager commandManager)
        {
            _shapes = new List<IShape>();
            _isPressed = false;
            _commandManager = commandManager;
            _state = new PointerState(commandManager, this);
        }

        public bool IsAnyShapeDisplayed
        {
            get
            {
                return _commandManager.IsAnyCommandExecuted;
            }
        }

        public bool IsAnyShapeRemoved
        {
            get
            {
                return _commandManager.IsAnyCommandRevoked;
            }
        }

        public bool IsDrawing
        {
            get
            {
                return _state is DrawingState || _state is DrawingLineState;
            }
        }

        /// <summary>
        /// 選擇畫圖形
        /// </summary>
        /// <param name="shapeType"></param>
        public void ChooseShape(ShapeType shapeType)
        {
            _state = new DrawingState(_commandManager, this, ShapesFactory.CreateShape(shapeType));
        }

        /// <summary>
        /// 選擇畫線
        /// </summary>
        public void ChooseLine()
        {
            _state = new DrawingLineState(_commandManager, this);
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
                _state.PressPointer(locationX, locationY);
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
                _state.MovePointer(locationX, locationY);
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
                _state.ReleasePointer(locationX, locationY);
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
                _state.Draw(graphics);
            }
        }

        /// <summary>
        /// 清除所有繪製布
        /// </summary>
        public void Clear()
        {
            _commandManager.Execute(new ClearCommand(this, _shapes));
            _isPressed = false;
            NotifyModelChanged();
        }

        /// <summary>
        /// 重作
        /// </summary>
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        /// <summary>
        /// 復原
        /// </summary>
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }
    }
}

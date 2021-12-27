using DrawingModel.Commands;
using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public partial class Model : IModel
    {
        public event Action _modelChanged;

        private bool _isPressed;
        private bool _isSelected;
        private ShapeType _currentDrawingShapeType;

        private IShape _currentDrawingShape;
        private IShape _selectedShape;
        private readonly IList<IShape> _shapes;

        private readonly CommandManager _commandManager;

        public Model(CommandManager commandManager)
        {
            _shapes = new List<IShape>();
            _isPressed = _isSelected = false;
            _currentDrawingShapeType = ShapeType.None;
            _commandManager = commandManager;
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
                _currentDrawingShape = ShapesFactory.CreateShape(_currentDrawingShapeType);
                _isSelected = false;
                NotifyModelChanged();
            }
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

        public bool IsAnyShapeSelected
        {
            get
            {
                return _isSelected;
            }
        }

        public string SelectedShapeInfo
        {
            get
            {
                return _selectedShape != null ? _selectedShape.Info : string.Empty;
            }
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
                if (_currentDrawingShapeType != ShapeType.None)
                {
                    _currentDrawingShape.X1 = locationX;
                    _currentDrawingShape.Y1 = locationY;
                    _isPressed = true;
                }
                else
                {
                    _selectedShape = FindShapeByLocation(locationX, locationY);
                    _isSelected = _selectedShape != null;
                    NotifyModelChanged();
                }
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
            if (_isPressed)
            {
                IShape shape = CreateShape(locationX, locationY);
                if (shape != null)
                {
                    _commandManager.Execute(new DrawCommand(this, shape, _currentDrawingShapeType != ShapeType.Line));
                    // If dont want to use command pattern, remove this comment and comment the code above
                    // _shapes.Add(shape);
                    ResetDrawingShape();
                }

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
                DrawDashedLines(graphics, _currentDrawingShape);
            }
            if (_isSelected)
            {
                DrawDashedLines(graphics, _selectedShape);
                DrawDots(graphics, _selectedShape);
            }
        }

        /// <summary>
        /// 清除所有畫布
        /// </summary>
        public void Clear()
        {
            _commandManager.Execute(new ClearCommand(this, _shapes));
            _isPressed = false;
            ResetDrawingShape();
            NotifyModelChanged();
        }

        /// <summary>
        /// 重作
        /// </summary>
        public void Redo()
        {
            _commandManager.Redo();
            _isSelected = false;
            NotifyModelChanged();
        }

        /// <summary>
        /// 復原
        /// </summary>
        public void Undo()
        {
            _commandManager.Undo();
            _isSelected = false;
            NotifyModelChanged();
        }
    }
}

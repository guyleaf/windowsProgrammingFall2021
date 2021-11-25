using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();

        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed;
        private readonly List<Line> _lines;
        private readonly Line _hint;

        public Model()
        {
            _firstPointX = _firstPointY = -1;
            _isPressed = false;
            _lines = new List<Line>();
            _hint = new Line();
        }

        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint.x1 = _firstPointX;
                _hint.y1 = _firstPointY;
                _isPressed = true;
            }
        }

        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;

                var hint = new Line();
                hint.x1 = _firstPointX;
                hint.y1 = _firstPointY;
                hint.x2 = x;
                hint.y2 = y;
                _lines.Add(hint);

                NotifyModelChanged();
            }
        }

        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();

            NotifyModelChanged();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (var line in _lines)
            {
                line.Draw(graphics);
            }
            if (_isPressed)
            {
                _hint.Draw(graphics);
            }
        }

        void NotifyModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged();
        }
    }
}

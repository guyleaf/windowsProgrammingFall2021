using DrawingModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DrawingApp.PresentationModel
{
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        private readonly Canvas _canvas;

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = new SolidColorBrush(Colors.Black)
            };

            _canvas.Children.Add(line);
        }
    }
}
